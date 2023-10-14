using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Philter.Aura.Web.Models
{
    public partial class HouseDtoGen : GeneratedDto<Philter.Aura.Data.Models.House>
    {
        public HouseDtoGen() { }

        private int? _HouseId;
        private string _Name;
        private string _Address;
        private string _MainPhone;
        private string _AltPhone;
        private System.Collections.Generic.ICollection<Philter.Aura.Web.Models.HouseManagerDtoGen> _HouseManagers;
        private System.Collections.Generic.ICollection<Philter.Aura.Web.Models.RoomDtoGen> _Rooms;

        public int? HouseId
        {
            get => _HouseId;
            set { _HouseId = value; Changed(nameof(HouseId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public string Address
        {
            get => _Address;
            set { _Address = value; Changed(nameof(Address)); }
        }
        public string MainPhone
        {
            get => _MainPhone;
            set { _MainPhone = value; Changed(nameof(MainPhone)); }
        }
        public string AltPhone
        {
            get => _AltPhone;
            set { _AltPhone = value; Changed(nameof(AltPhone)); }
        }
        public System.Collections.Generic.ICollection<Philter.Aura.Web.Models.HouseManagerDtoGen> HouseManagers
        {
            get => _HouseManagers;
            set { _HouseManagers = value; Changed(nameof(HouseManagers)); }
        }
        public System.Collections.Generic.ICollection<Philter.Aura.Web.Models.RoomDtoGen> Rooms
        {
            get => _Rooms;
            set { _Rooms = value; Changed(nameof(Rooms)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Philter.Aura.Data.Models.House obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.HouseId = obj.HouseId;
            this.Name = obj.Name;
            this.Address = obj.Address;
            this.MainPhone = obj.MainPhone;
            this.AltPhone = obj.AltPhone;
            var propValHouseManagers = obj.HouseManagers;
            if (propValHouseManagers != null && (tree == null || tree[nameof(this.HouseManagers)] != null))
            {
                this.HouseManagers = propValHouseManagers
                    .OrderBy(f => f.HouseManagerId)
                    .Select(f => f.MapToDto<Philter.Aura.Data.Models.HouseManager, HouseManagerDtoGen>(context, tree?[nameof(this.HouseManagers)])).ToList();
            }
            else if (propValHouseManagers == null && tree?[nameof(this.HouseManagers)] != null)
            {
                this.HouseManagers = new HouseManagerDtoGen[0];
            }

            var propValRooms = obj.Rooms;
            if (propValRooms != null && (tree == null || tree[nameof(this.Rooms)] != null))
            {
                this.Rooms = propValRooms
                    .OrderBy(f => f.Name)
                    .Select(f => f.MapToDto<Philter.Aura.Data.Models.Room, RoomDtoGen>(context, tree?[nameof(this.Rooms)])).ToList();
            }
            else if (propValRooms == null && tree?[nameof(this.Rooms)] != null)
            {
                this.Rooms = new RoomDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Philter.Aura.Data.Models.House entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(HouseId))) entity.HouseId = (HouseId ?? entity.HouseId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Address))) entity.Address = Address;
            if (ShouldMapTo(nameof(MainPhone))) entity.MainPhone = MainPhone;
            if (ShouldMapTo(nameof(AltPhone))) entity.AltPhone = AltPhone;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Philter.Aura.Data.Models.House MapToNew(IMappingContext context)
        {
            var entity = new Philter.Aura.Data.Models.House();
            MapTo(entity, context);
            return entity;
        }
    }
}
