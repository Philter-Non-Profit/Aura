using IntelliTect.Coalesce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Philter.Aura.Data.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using static Philter.Aura.Data.Services.MessagingService;

namespace Philter.Aura.Data.Services;

[Coalesce, Service]
public interface IMessagingService
{
    [Execute(SecurityPermissionLevels.AllowAuthorized)]
    public Task<ItemResult<MessageResource>> SendText(ClaimsPrincipal claim, PhoneNumber to, string messagingServiceId, Message message);
    [Execute(SecurityPermissionLevels.AllowAuthorized)]
    public Task<ItemResult<MessageResource>> SendTextAt(ClaimsPrincipal claim, PhoneNumber to, string messagingServiceId, Message message, DateTime messageTime, [Inject] IHttpContextAccessor httpContext);
    public void UpdateMessageStatusCallback([FromBody] MessageStatusCallbackDto result);
    }