using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Philter.Aura.Data.Models;
using Philter.Aura.Data.Options;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Twilio;
using IntelliTect.Coalesce.Models;
using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Proxy.V1.Service.Session.Participant;
using Twilio.Types;

namespace Philter.Aura.Data.Services;


public class MessagingService : IMessagingService
{
    private readonly IOptions<TwilioOptions> _twilioOptions;
    private readonly AuraDbContext _dbContext;
    MessagingService(IOptions<TwilioOptions> options, AuraDbContext db)
    {
        _twilioOptions = options;
        _dbContext = db;
    }
    public async Task<ItemResult<MessageResource>> SendText(ClaimsPrincipal claim, PhoneNumber to, string messagingServiceId, Message message)
    {
        var result = await MessageResource.CreateAsync(to: to, body: message.MessageBody,
            messagingServiceSid: messagingServiceId);

        _dbContext.MessageToRecipients.Add(new()
        {
            MessageId = message.MessageId,
            TwilioMessageSid = result.Sid,
            SenderId = new Guid(claim.GetUserId()!),
            StatusId = MessageStatusEnum.InProgress,
            DateSent = DateTime.Now,
        });
        await _dbContext.SaveChangesAsync();


        if (result.ErrorMessage != null)
        {
            return result.ErrorMessage;
        }

        return result;
    }

    public async Task<ItemResult<MessageResource>> SendTextAt(ClaimsPrincipal claim, PhoneNumber to, string messagingServiceId, Message message, DateTime messageTime, [Inject] IHttpContextAccessor httpContext)
    {
        if (DateTime.Now.AddDays(7) < messageTime)
        {
            return "You cannot schedule a message further than 7 days in advance.";
        }

        var result = await MessageResource.CreateAsync(to: to, body: message.MessageBody,
            messagingServiceSid: messagingServiceId, sendAt: messageTime, statusCallback: new Uri(httpContext.HttpContext?.Request.Path.Value + (nameof(UpdateMessageStatusCallback))));

        _dbContext.MessageToRecipients.Add(new()
        {
            MessageId = message.MessageId,
            TwilioMessageSid = result.Sid,
            SenderId = new Guid(claim.GetUserId()!),
            StatusId = MessageStatusEnum.InProgress,
            DateSent = messageTime,
        });
        await _dbContext.SaveChangesAsync();

        UpdateMessageStatusCallback(new MessageStatusCallbackDto(_twilioOptions.Value.AccountSid, result.From.ToString(), result.Sid, result.Status.ToString(), null, null));

        if (result.ErrorMessage != null)
        {
            return result.ErrorMessage;
        }

        return result;
    }

    public void UpdateMessageStatusCallback([FromBody] MessageStatusCallbackDto result)
    {
        if (result.AccountSid != _twilioOptions.Value.AccountSid)
        {
            return;
        }

        var message = _dbContext.MessageToRecipients.Single(m => m.TwilioMessageSid == result.MessageSid);
        if (result.MessageStatus == MessageResource.StatusEnum.Received.ToString())
        {
            message.StatusId = MessageStatusEnum.Recieved;
        }
        else
        {
            message.StatusId = MessageStatusEnum.Failed;
        }
        _dbContext.SaveChanges();
    }

    // Record DTO for Twilio callback
    public record MessageStatusCallbackDto(string AccountSid, string From, string MessageSid, string MessageStatus, string? smsSid, string? SmsStatus);
}