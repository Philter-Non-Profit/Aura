using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Philter.Aura.Web.Models
{
    public partial class MessageToRecipientDtoGen : GeneratedDto<Philter.Aura.Data.Models.MessageToRecipient>
    {
        public MessageToRecipientDtoGen() { }

        private long? _MessageToRecipientId;
        private long? _MessageId;
        private Philter.Aura.Web.Models.MessageDtoGen _Message;
        private string _TwilioMessageSid;
        private long? _RecipientId;
        private Philter.Aura.Web.Models.RecipientDtoGen _Recipient;
        private System.Guid? _SenderId;
        private Philter.Aura.Web.Models.AuraUserDtoGen _Sender;
        private Philter.Aura.Data.Models.MessageStatusEnum? _StatusId;
        private System.DateTime? _DateSent;

        public long? MessageToRecipientId
        {
            get => _MessageToRecipientId;
            set { _MessageToRecipientId = value; Changed(nameof(MessageToRecipientId)); }
        }
        public long? MessageId
        {
            get => _MessageId;
            set { _MessageId = value; Changed(nameof(MessageId)); }
        }
        public Philter.Aura.Web.Models.MessageDtoGen Message
        {
            get => _Message;
            set { _Message = value; Changed(nameof(Message)); }
        }
        public string TwilioMessageSid
        {
            get => _TwilioMessageSid;
            set { _TwilioMessageSid = value; Changed(nameof(TwilioMessageSid)); }
        }
        public long? RecipientId
        {
            get => _RecipientId;
            set { _RecipientId = value; Changed(nameof(RecipientId)); }
        }
        public Philter.Aura.Web.Models.RecipientDtoGen Recipient
        {
            get => _Recipient;
            set { _Recipient = value; Changed(nameof(Recipient)); }
        }
        public System.Guid? SenderId
        {
            get => _SenderId;
            set { _SenderId = value; Changed(nameof(SenderId)); }
        }
        public Philter.Aura.Web.Models.AuraUserDtoGen Sender
        {
            get => _Sender;
            set { _Sender = value; Changed(nameof(Sender)); }
        }
        public Philter.Aura.Data.Models.MessageStatusEnum? StatusId
        {
            get => _StatusId;
            set { _StatusId = value; Changed(nameof(StatusId)); }
        }
        public System.DateTime? DateSent
        {
            get => _DateSent;
            set { _DateSent = value; Changed(nameof(DateSent)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Philter.Aura.Data.Models.MessageToRecipient obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.MessageToRecipientId = obj.MessageToRecipientId;
            this.MessageId = obj.MessageId;
            this.TwilioMessageSid = obj.TwilioMessageSid;
            this.RecipientId = obj.RecipientId;
            this.SenderId = obj.SenderId;
            this.StatusId = obj.StatusId;
            this.DateSent = obj.DateSent;
            if (tree == null || tree[nameof(this.Message)] != null)
                this.Message = obj.Message.MapToDto<Philter.Aura.Data.Models.Message, MessageDtoGen>(context, tree?[nameof(this.Message)]);

            if (tree == null || tree[nameof(this.Recipient)] != null)
                this.Recipient = obj.Recipient.MapToDto<Philter.Aura.Data.Models.Recipient, RecipientDtoGen>(context, tree?[nameof(this.Recipient)]);

            if (tree == null || tree[nameof(this.Sender)] != null)
                this.Sender = obj.Sender.MapToDto<Philter.Aura.Data.Models.AuraUser, AuraUserDtoGen>(context, tree?[nameof(this.Sender)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Philter.Aura.Data.Models.MessageToRecipient entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(MessageToRecipientId))) entity.MessageToRecipientId = (MessageToRecipientId ?? entity.MessageToRecipientId);
            if (ShouldMapTo(nameof(MessageId))) entity.MessageId = (MessageId ?? entity.MessageId);
            if (ShouldMapTo(nameof(TwilioMessageSid))) entity.TwilioMessageSid = TwilioMessageSid;
            if (ShouldMapTo(nameof(RecipientId))) entity.RecipientId = (RecipientId ?? entity.RecipientId);
            if (ShouldMapTo(nameof(SenderId))) entity.SenderId = (SenderId ?? entity.SenderId);
            if (ShouldMapTo(nameof(StatusId))) entity.StatusId = (StatusId ?? entity.StatusId);
            if (ShouldMapTo(nameof(DateSent))) entity.DateSent = (DateSent ?? entity.DateSent);
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Philter.Aura.Data.Models.MessageToRecipient MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new Philter.Aura.Data.Models.MessageToRecipient()
            {
                TwilioMessageSid = TwilioMessageSid,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(MessageToRecipientId))) entity.MessageToRecipientId = (MessageToRecipientId ?? entity.MessageToRecipientId);
            if (ShouldMapTo(nameof(MessageId))) entity.MessageId = (MessageId ?? entity.MessageId);
            if (ShouldMapTo(nameof(RecipientId))) entity.RecipientId = (RecipientId ?? entity.RecipientId);
            if (ShouldMapTo(nameof(SenderId))) entity.SenderId = (SenderId ?? entity.SenderId);
            if (ShouldMapTo(nameof(StatusId))) entity.StatusId = (StatusId ?? entity.StatusId);
            if (ShouldMapTo(nameof(DateSent))) entity.DateSent = (DateSent ?? entity.DateSent);

            return entity;
        }
    }
}
