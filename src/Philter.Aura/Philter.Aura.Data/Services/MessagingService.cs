using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Philter.Aura.Data.Services;


public class MessagingService : IMessagingService
{
    public MessageResource SendText(PhoneNumber to, string messagingServiceId, string message)
    {
        return MessageResource.Create(to: to, body: message,
            messagingServiceSid: messagingServiceId);
    }
}