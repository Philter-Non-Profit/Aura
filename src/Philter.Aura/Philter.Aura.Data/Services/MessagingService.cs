using IntelliTect.Coalesce.Models;
using System;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
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
        var result = await MessageResource.CreateAsync(to: to, body: message,
            messagingServiceSid: messagingServiceId, sendAt: messageTime);

        if (result.ErrorMessage != null)
        {
            return result.ErrorMessage;
        }

        return result;
    }
}