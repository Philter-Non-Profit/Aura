using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Philter.Aura.Web.Models
{
    public partial class PhoneNumberDtoGen : GeneratedDto<Twilio.Types.PhoneNumber>
    {
        public PhoneNumberDtoGen() { }



        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Twilio.Types.PhoneNumber obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Twilio.Types.PhoneNumber entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Twilio.Types.PhoneNumber MapToNew(IMappingContext context)
        {
            // Unacceptable constructors:
            // .ctor(string number): There is no incoming property named `number`, so Coalesce cannot provide a value for that constructor parameter.
            throw new NotSupportedException("Type PhoneNumber has no initializable properties and so cannot be used as an input to any Coalesce-generated APIs.");
        }
    }
}
