using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Philter.Aura.Web.Models
{
    public partial class RecipientDtoGen : GeneratedDto<Philter.Aura.Data.Models.Recipient>
    {
        public RecipientDtoGen() { }

        private long? _RecipientId;
        private string _RecipientName;
        private string _RecipientPhoneNumber;
        private System.Collections.Generic.ICollection<Philter.Aura.Web.Models.MessageDtoGen> _Messages;

        public long? RecipientId
        {
            get => _RecipientId;
            set { _RecipientId = value; Changed(nameof(RecipientId)); }
        }
        public string RecipientName
        {
            get => _RecipientName;
            set { _RecipientName = value; Changed(nameof(RecipientName)); }
        }
        public string RecipientPhoneNumber
        {
            get => _RecipientPhoneNumber;
            set { _RecipientPhoneNumber = value; Changed(nameof(RecipientPhoneNumber)); }
        }
        public System.Collections.Generic.ICollection<Philter.Aura.Web.Models.MessageDtoGen> Messages
        {
            get => _Messages;
            set { _Messages = value; Changed(nameof(Messages)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Philter.Aura.Data.Models.Recipient obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.RecipientId = obj.RecipientId;
            this.RecipientName = obj.RecipientName;
            this.RecipientPhoneNumber = obj.RecipientPhoneNumber;
            var propValMessages = obj.Messages;
            if (propValMessages != null && (tree == null || tree[nameof(this.Messages)] != null))
            {
                this.Messages = propValMessages
                    .OrderBy(f => f.MessageId)
                    .Select(f => f.MapToDto<Philter.Aura.Data.Models.Message, MessageDtoGen>(context, tree?[nameof(this.Messages)])).ToList();
            }
            else if (propValMessages == null && tree?[nameof(this.Messages)] != null)
            {
                this.Messages = new MessageDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Philter.Aura.Data.Models.Recipient entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(RecipientId))) entity.RecipientId = (RecipientId ?? entity.RecipientId);
            if (ShouldMapTo(nameof(RecipientName))) entity.RecipientName = RecipientName;
            if (ShouldMapTo(nameof(RecipientPhoneNumber))) entity.RecipientPhoneNumber = RecipientPhoneNumber;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Philter.Aura.Data.Models.Recipient MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new Philter.Aura.Data.Models.Recipient()
            {
                RecipientName = RecipientName,
                RecipientPhoneNumber = RecipientPhoneNumber,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(RecipientId))) entity.RecipientId = (RecipientId ?? entity.RecipientId);

            return entity;
        }
    }
}
