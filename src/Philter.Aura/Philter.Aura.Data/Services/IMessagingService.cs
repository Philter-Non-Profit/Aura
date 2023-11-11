using IntelliTect.Coalesce.Models;
using System;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Philter.Aura.Data.Services;

[Coalesce, Service]
public interface IMessagingService
{
    [Execute(SecurityPermissionLevels.AllowAuthorized)]
    public Task<ItemResult<MessageResource>> SendText(string to, string messagingServiceId, string message);
    [Execute(SecurityPermissionLevels.AllowAuthorized)]
    public Task<ItemResult<MessageResource>> SendTextAt(string to, string messagingServiceId, string message, DateTime messageTime);
}