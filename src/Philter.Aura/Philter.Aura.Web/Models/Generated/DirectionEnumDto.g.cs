using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Philter.Aura.Web.Models
{
    public partial class DirectionEnumDtoGen : GeneratedDto<Twilio.Rest.Api.V2010.Account.MessageResource.DirectionEnum>
    {
        public DirectionEnumDtoGen() { }



        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Twilio.Rest.Api.V2010.Account.MessageResource.DirectionEnum obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Twilio.Rest.Api.V2010.Account.MessageResource.DirectionEnum entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Twilio.Rest.Api.V2010.Account.MessageResource.DirectionEnum MapToNew(IMappingContext context)
        {
            var entity = new Twilio.Rest.Api.V2010.Account.MessageResource.DirectionEnum();
            MapTo(entity, context);
            return entity;
        }
    }
}
