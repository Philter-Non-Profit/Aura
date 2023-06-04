using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Philter.Aura.Web.Models
{
    public partial class AuraUserDtoGen : GeneratedDto<Philter.Aura.Data.Models.AuraUser>
    {
        public AuraUserDtoGen() { }

        private System.Guid? _AuraUserId;
        private string _Name;
        private string _Email;
        private System.DateTimeOffset? _LastLogin;
        private System.Collections.Generic.ICollection<Philter.Aura.Web.Models.HouseDtoGen> _ManagedHouses;

        public System.Guid? AuraUserId
        {
            get => _AuraUserId;
            set { _AuraUserId = value; Changed(nameof(AuraUserId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public string Email
        {
            get => _Email;
            set { _Email = value; Changed(nameof(Email)); }
        }
        public System.DateTimeOffset? LastLogin
        {
            get => _LastLogin;
            set { _LastLogin = value; Changed(nameof(LastLogin)); }
        }
        public System.Collections.Generic.ICollection<Philter.Aura.Web.Models.HouseDtoGen> ManagedHouses
        {
            get => _ManagedHouses;
            set { _ManagedHouses = value; Changed(nameof(ManagedHouses)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Philter.Aura.Data.Models.AuraUser obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.AuraUserId = obj.AuraUserId;
            this.Name = obj.Name;
            this.Email = obj.Email;
            this.LastLogin = obj.LastLogin;
            var propValManagedHouses = obj.ManagedHouses;
            if (propValManagedHouses != null && (tree == null || tree[nameof(this.ManagedHouses)] != null))
            {
                this.ManagedHouses = propValManagedHouses
                    .OrderBy(f => f.Name)
                    .Select(f => f.MapToDto<Philter.Aura.Data.Models.House, HouseDtoGen>(context, tree?[nameof(this.ManagedHouses)])).ToList();
            }
            else if (propValManagedHouses == null && tree?[nameof(this.ManagedHouses)] != null)
            {
                this.ManagedHouses = new HouseDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Philter.Aura.Data.Models.AuraUser entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(AuraUserId))) entity.AuraUserId = (AuraUserId ?? entity.AuraUserId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Email))) entity.Email = Email;
            if (ShouldMapTo(nameof(LastLogin))) entity.LastLogin = LastLogin;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Philter.Aura.Data.Models.AuraUser MapToNew(IMappingContext context)
        {
            var entity = new Philter.Aura.Data.Models.AuraUser();
            MapTo(entity, context);
            return entity;
        }
    }
}
