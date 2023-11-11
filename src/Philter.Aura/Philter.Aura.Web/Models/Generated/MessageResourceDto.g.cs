using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Philter.Aura.Web.Models
{
    public partial class MessageResourceDtoGen : GeneratedDto<Twilio.Rest.Api.V2010.Account.MessageResource>
    {
        public MessageResourceDtoGen() { }

        private string _Body;
        private string _NumSegments;
        private Philter.Aura.Web.Models.DirectionEnumDtoGen _Direction;
        private Philter.Aura.Web.Models.PhoneNumberDtoGen _From;
        private string _To;
        private System.DateTime? _DateUpdated;
        private string _Price;
        private string _ErrorMessage;
        private string _Uri;
        private string _AccountSid;
        private string _NumMedia;
        private Philter.Aura.Web.Models.StatusEnumDtoGen _Status;
        private string _MessagingServiceSid;
        private string _Sid;
        private System.DateTime? _DateSent;
        private System.DateTime? _DateCreated;
        private int? _ErrorCode;
        private string _PriceUnit;
        private string _ApiVersion;
        private System.Collections.Generic.IDictionary<string, string> _SubresourceUris;

        public string Body
        {
            get => _Body;
            set { _Body = value; Changed(nameof(Body)); }
        }
        public string NumSegments
        {
            get => _NumSegments;
            set { _NumSegments = value; Changed(nameof(NumSegments)); }
        }
        public Philter.Aura.Web.Models.DirectionEnumDtoGen Direction
        {
            get => _Direction;
            set { _Direction = value; Changed(nameof(Direction)); }
        }
        public Philter.Aura.Web.Models.PhoneNumberDtoGen From
        {
            get => _From;
            set { _From = value; Changed(nameof(From)); }
        }
        public string To
        {
            get => _To;
            set { _To = value; Changed(nameof(To)); }
        }
        public System.DateTime? DateUpdated
        {
            get => _DateUpdated;
            set { _DateUpdated = value; Changed(nameof(DateUpdated)); }
        }
        public string Price
        {
            get => _Price;
            set { _Price = value; Changed(nameof(Price)); }
        }
        public string ErrorMessage
        {
            get => _ErrorMessage;
            set { _ErrorMessage = value; Changed(nameof(ErrorMessage)); }
        }
        public string Uri
        {
            get => _Uri;
            set { _Uri = value; Changed(nameof(Uri)); }
        }
        public string AccountSid
        {
            get => _AccountSid;
            set { _AccountSid = value; Changed(nameof(AccountSid)); }
        }
        public string NumMedia
        {
            get => _NumMedia;
            set { _NumMedia = value; Changed(nameof(NumMedia)); }
        }
        public Philter.Aura.Web.Models.StatusEnumDtoGen Status
        {
            get => _Status;
            set { _Status = value; Changed(nameof(Status)); }
        }
        public string MessagingServiceSid
        {
            get => _MessagingServiceSid;
            set { _MessagingServiceSid = value; Changed(nameof(MessagingServiceSid)); }
        }
        public string Sid
        {
            get => _Sid;
            set { _Sid = value; Changed(nameof(Sid)); }
        }
        public System.DateTime? DateSent
        {
            get => _DateSent;
            set { _DateSent = value; Changed(nameof(DateSent)); }
        }
        public System.DateTime? DateCreated
        {
            get => _DateCreated;
            set { _DateCreated = value; Changed(nameof(DateCreated)); }
        }
        public int? ErrorCode
        {
            get => _ErrorCode;
            set { _ErrorCode = value; Changed(nameof(ErrorCode)); }
        }
        public string PriceUnit
        {
            get => _PriceUnit;
            set { _PriceUnit = value; Changed(nameof(PriceUnit)); }
        }
        public string ApiVersion
        {
            get => _ApiVersion;
            set { _ApiVersion = value; Changed(nameof(ApiVersion)); }
        }
        public System.Collections.Generic.IDictionary<string, string> SubresourceUris
        {
            get => _SubresourceUris;
            set { _SubresourceUris = value; Changed(nameof(SubresourceUris)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Twilio.Rest.Api.V2010.Account.MessageResource obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.Body = obj.Body;
            this.NumSegments = obj.NumSegments;
            this.To = obj.To;
            this.DateUpdated = obj.DateUpdated;
            this.Price = obj.Price;
            this.ErrorMessage = obj.ErrorMessage;
            this.Uri = obj.Uri;
            this.AccountSid = obj.AccountSid;
            this.NumMedia = obj.NumMedia;
            this.MessagingServiceSid = obj.MessagingServiceSid;
            this.Sid = obj.Sid;
            this.DateSent = obj.DateSent;
            this.DateCreated = obj.DateCreated;
            this.ErrorCode = obj.ErrorCode;
            this.PriceUnit = obj.PriceUnit;
            this.ApiVersion = obj.ApiVersion;
            this.SubresourceUris = obj.SubresourceUris;

            this.Direction = obj.Direction.MapToDto<Twilio.Rest.Api.V2010.Account.MessageResource.DirectionEnum, DirectionEnumDtoGen>(context, tree?[nameof(this.Direction)]);


            this.From = obj.From.MapToDto<Twilio.Types.PhoneNumber, PhoneNumberDtoGen>(context, tree?[nameof(this.From)]);


            this.Status = obj.Status.MapToDto<Twilio.Rest.Api.V2010.Account.MessageResource.StatusEnum, StatusEnumDtoGen>(context, tree?[nameof(this.Status)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Twilio.Rest.Api.V2010.Account.MessageResource entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Twilio.Rest.Api.V2010.Account.MessageResource MapToNew(IMappingContext context)
        {
            // Unacceptable constructors:
            // Type has no public constructors.
            throw new NotSupportedException("Type MessageResource has no initializable properties and so cannot be used as an input to any Coalesce-generated APIs.");
        }
    }
}
