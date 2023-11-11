using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Philter.Aura.Web.Models
{
    public partial class MessageDtoGen : GeneratedDto<Philter.Aura.Data.Models.Message>
    {
        public MessageDtoGen() { }

        private long? _MessageId;
        private string _MessageBody;

        public long? MessageId
        {
            get => _MessageId;
            set { _MessageId = value; Changed(nameof(MessageId)); }
        }
        public string MessageBody
        {
            get => _MessageBody;
            set { _MessageBody = value; Changed(nameof(MessageBody)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Philter.Aura.Data.Models.Message obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.MessageId = obj.MessageId;
            this.MessageBody = obj.MessageBody;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Philter.Aura.Data.Models.Message entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(MessageId))) entity.MessageId = (MessageId ?? entity.MessageId);
            if (ShouldMapTo(nameof(MessageBody))) entity.MessageBody = MessageBody;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Philter.Aura.Data.Models.Message MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new Philter.Aura.Data.Models.Message()
            {
                MessageBody = MessageBody,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(MessageId))) entity.MessageId = (MessageId ?? entity.MessageId);

            return entity;
        }
    }
}
