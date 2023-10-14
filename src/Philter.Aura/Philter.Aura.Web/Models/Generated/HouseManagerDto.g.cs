using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Philter.Aura.Web.Models
{
    public partial class HouseManagerDtoGen : GeneratedDto<Philter.Aura.Data.Models.HouseManager>
    {
        public HouseManagerDtoGen() { }

        private int? _HouseManagerId;
        private int? _HouseId;
        private Philter.Aura.Web.Models.HouseDtoGen _House;
        private System.Guid? _AuraUserId;
        private Philter.Aura.Web.Models.AuraUserDtoGen _AuraUser;

        public int? HouseManagerId
        {
            get => _HouseManagerId;
            set { _HouseManagerId = value; Changed(nameof(HouseManagerId)); }
        }
        public int? HouseId
        {
            get => _HouseId;
            set { _HouseId = value; Changed(nameof(HouseId)); }
        }
        public Philter.Aura.Web.Models.HouseDtoGen House
        {
            get => _House;
            set { _House = value; Changed(nameof(House)); }
        }
        public System.Guid? AuraUserId
        {
            get => _AuraUserId;
            set { _AuraUserId = value; Changed(nameof(AuraUserId)); }
        }
        public Philter.Aura.Web.Models.AuraUserDtoGen AuraUser
        {
            get => _AuraUser;
            set { _AuraUser = value; Changed(nameof(AuraUser)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Philter.Aura.Data.Models.HouseManager obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.HouseManagerId = obj.HouseManagerId;
            this.HouseId = obj.HouseId;
            this.AuraUserId = obj.AuraUserId;
            if (tree == null || tree[nameof(this.House)] != null)
                this.House = obj.House.MapToDto<Philter.Aura.Data.Models.House, HouseDtoGen>(context, tree?[nameof(this.House)]);

            if (tree == null || tree[nameof(this.AuraUser)] != null)
                this.AuraUser = obj.AuraUser.MapToDto<Philter.Aura.Data.Models.AuraUser, AuraUserDtoGen>(context, tree?[nameof(this.AuraUser)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Philter.Aura.Data.Models.HouseManager entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(HouseManagerId))) entity.HouseManagerId = (HouseManagerId ?? entity.HouseManagerId);
            if (ShouldMapTo(nameof(HouseId))) entity.HouseId = (HouseId ?? entity.HouseId);
            if (ShouldMapTo(nameof(AuraUserId))) entity.AuraUserId = (AuraUserId ?? entity.AuraUserId);
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Philter.Aura.Data.Models.HouseManager MapToNew(IMappingContext context)
        {
            var entity = new Philter.Aura.Data.Models.HouseManager();
            MapTo(entity, context);
            return entity;
        }
    }
}
