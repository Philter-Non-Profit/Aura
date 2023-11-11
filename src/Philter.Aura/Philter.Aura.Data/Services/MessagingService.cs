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
    public async Task<ItemResult<MessageResource>> SendText(PhoneNumber to, string messagingServiceId, string message)
    {
        var result = await MessageResource.CreateAsync(to: to, body: message,
            messagingServiceSid: messagingServiceId);

        if (result.ErrorMessage != null)
        {
            return result.ErrorMessage;
        }

        return result;
    }

    public async Task<ItemResult<MessageResource>> SendTextAt(PhoneNumber to, string messagingServiceId, string message, DateTime messageTime)
    {
        if(DateTime.Now.AddDays(7) < messageTime)
        {
            return "You cannot schedule a message further than 7 days in advance.";
        }
        var result = await MessageResource.CreateAsync(to: to, body: message,
            messagingServiceSid: messagingServiceId, sendAt: messageTime);

        if (result.ErrorMessage != null)
        {
            return result.ErrorMessage;
        }

        return result;
    }
}