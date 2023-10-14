using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Philter.Aura.Web.Models
{
    public partial class RoomDtoGen : GeneratedDto<Philter.Aura.Data.Models.Room>
    {
        public RoomDtoGen() { }

        private int? _RoomId;
        private int? _HouseId;
        private Philter.Aura.Web.Models.HouseDtoGen _House;
        private string _Name;
        private string _Notes;

        public int? RoomId
        {
            get => _RoomId;
            set { _RoomId = value; Changed(nameof(RoomId)); }
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
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public string Notes
        {
            get => _Notes;
            set { _Notes = value; Changed(nameof(Notes)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Philter.Aura.Data.Models.Room obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.RoomId = obj.RoomId;
            this.HouseId = obj.HouseId;
            this.Name = obj.Name;
            this.Notes = obj.Notes;
            if (tree == null || tree[nameof(this.House)] != null)
                this.House = obj.House.MapToDto<Philter.Aura.Data.Models.House, HouseDtoGen>(context, tree?[nameof(this.House)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Philter.Aura.Data.Models.Room entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(RoomId))) entity.RoomId = (RoomId ?? entity.RoomId);
            if (ShouldMapTo(nameof(HouseId))) entity.HouseId = (HouseId ?? entity.HouseId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Notes))) entity.Notes = Notes;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Philter.Aura.Data.Models.Room MapToNew(IMappingContext context)
        {
            var entity = new Philter.Aura.Data.Models.Room();
            MapTo(entity, context);
            return entity;
        }
    }
}
