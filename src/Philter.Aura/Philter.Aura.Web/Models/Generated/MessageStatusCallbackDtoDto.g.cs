using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Philter.Aura.Web.Models
{
    public partial class MessageStatusCallbackDtoDtoGen : GeneratedDto<Philter.Aura.Data.Services.MessagingService.MessageStatusCallbackDto>
    {
        public MessageStatusCallbackDtoDtoGen() { }

        private string _AccountSid;
        private string _From;
        private string _MessageSid;
        private string _MessageStatus;
        private string _smsSid;
        private string _SmsStatus;

        public string AccountSid
        {
            get => _AccountSid;
            set { _AccountSid = value; Changed(nameof(AccountSid)); }
        }
        public string From
        {
            get => _From;
            set { _From = value; Changed(nameof(From)); }
        }
        public string MessageSid
        {
            get => _MessageSid;
            set { _MessageSid = value; Changed(nameof(MessageSid)); }
        }
        public string MessageStatus
        {
            get => _MessageStatus;
            set { _MessageStatus = value; Changed(nameof(MessageStatus)); }
        }
        public string smsSid
        {
            get => _smsSid;
            set { _smsSid = value; Changed(nameof(smsSid)); }
        }
        public string SmsStatus
        {
            get => _SmsStatus;
            set { _SmsStatus = value; Changed(nameof(SmsStatus)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Philter.Aura.Data.Services.MessagingService.MessageStatusCallbackDto obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.AccountSid = obj.AccountSid;
            this.From = obj.From;
            this.MessageSid = obj.MessageSid;
            this.MessageStatus = obj.MessageStatus;
            this.smsSid = obj.smsSid;
            this.SmsStatus = obj.SmsStatus;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Philter.Aura.Data.Services.MessagingService.MessageStatusCallbackDto entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Philter.Aura.Data.Services.MessagingService.MessageStatusCallbackDto MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new Philter.Aura.Data.Services.MessagingService.MessageStatusCallbackDto(
                AccountSid,
                From,
                MessageSid,
                MessageStatus,
                smsSid,
                SmsStatus
            )
            {
                AccountSid = AccountSid,
                From = From,
                MessageSid = MessageSid,
                MessageStatus = MessageStatus,
                smsSid = smsSid,
                SmsStatus = SmsStatus,
            };

            if (OnUpdate(entity, context)) return entity;

            return entity;
        }
    }
}
