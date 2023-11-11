using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Philter.Aura.Data.Services;

[Coalesce, Service]
public interface IMessagingService
{
	[Execute(SecurityPermissionLevels.AllowAuthorized)]
	public MessageResource SendText(PhoneNumber to, string messagingServiceId, string message);
}