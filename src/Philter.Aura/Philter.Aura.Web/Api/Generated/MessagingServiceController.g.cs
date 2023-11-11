
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Behaviors;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Philter.Aura.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Philter.Aura.Web.Api
{
    [Route("api/MessagingService")]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class MessagingServiceController : Controller
    {
        protected ClassViewModel GeneratedForClassViewModel { get; }
        protected Philter.Aura.Data.Services.IMessagingService Service { get; }
        protected CrudContext Context { get; }

        public MessagingServiceController(CrudContext context, Philter.Aura.Data.Services.IMessagingService service)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Philter.Aura.Data.Services.IMessagingService>();
            Service = service;
            Context = context;
        }

        /// <summary>
        /// Method: SendText
        /// </summary>
        [HttpPost("SendText")]
        [Authorize]
        public virtual async Task<ItemResult<MessageResourceDtoGen>> SendText(
            [FromForm(Name = "to")] PhoneNumberDtoGen to,
            [FromForm(Name = "messagingServiceId")] string messagingServiceId,
            [FromForm(Name = "message")] string message)
        {
            var _params = new
            {
                to = to,
                messagingServiceId = messagingServiceId,
                message = message
            };

            if (Context.Options.ValidateAttributesForMethods)
            {
                var _validationResult = ItemResult.FromParameterValidation(
                    GeneratedForClassViewModel!.MethodByName("SendText"), _params, HttpContext.RequestServices);
                if (!_validationResult.WasSuccessful) return new ItemResult<MessageResourceDtoGen>(_validationResult);
            }

            IncludeTree includeTree = null;
            var _mappingContext = new MappingContext(Context);
            var _methodResult = await Service.SendText(
                _params.to.MapToNew(_mappingContext),
                _params.messagingServiceId,
                _params.message
            );
            var _result = new ItemResult<MessageResourceDtoGen>(_methodResult);
            _result.Object = Mapper.MapToDto<Twilio.Rest.Api.V2010.Account.MessageResource, MessageResourceDtoGen>(_methodResult.Object, _mappingContext, includeTree ?? _methodResult.IncludeTree);
            return _result;
        }

        /// <summary>
        /// Method: SendTextAt
        /// </summary>
        [HttpPost("SendTextAt")]
        [Authorize]
        public virtual async Task<ItemResult<MessageResourceDtoGen>> SendTextAt(
            [FromForm(Name = "to")] PhoneNumberDtoGen to,
            [FromForm(Name = "messagingServiceId")] string messagingServiceId,
            [FromForm(Name = "message")] string message,
            [FromForm(Name = "messageTime")] System.DateTime messageTime)
        {
            var _params = new
            {
                to = to,
                messagingServiceId = messagingServiceId,
                message = message,
                messageTime = messageTime
            };

            if (Context.Options.ValidateAttributesForMethods)
            {
                var _validationResult = ItemResult.FromParameterValidation(
                    GeneratedForClassViewModel!.MethodByName("SendTextAt"), _params, HttpContext.RequestServices);
                if (!_validationResult.WasSuccessful) return new ItemResult<MessageResourceDtoGen>(_validationResult);
            }

            IncludeTree includeTree = null;
            var _mappingContext = new MappingContext(Context);
            var _methodResult = await Service.SendTextAt(
                _params.to.MapToNew(_mappingContext),
                _params.messagingServiceId,
                _params.message,
                _params.messageTime
            );
            var _result = new ItemResult<MessageResourceDtoGen>(_methodResult);
            _result.Object = Mapper.MapToDto<Twilio.Rest.Api.V2010.Account.MessageResource, MessageResourceDtoGen>(_methodResult.Object, _mappingContext, includeTree ?? _methodResult.IncludeTree);
            return _result;
        }
    }
}
