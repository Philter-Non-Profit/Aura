
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Philter.Aura.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Philter.Aura.Web.Api
{
    [Route("api/House")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class HouseController
        : BaseApiController<Philter.Aura.Data.Models.House, HouseDtoGen, Philter.Aura.Data.AuraDbContext>
    {
        public HouseController(CrudContext<Philter.Aura.Data.AuraDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Philter.Aura.Data.Models.House>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<HouseDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<Philter.Aura.Data.Models.House> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<HouseDtoGen>> List(
            ListParameters parameters,
            IDataSource<Philter.Aura.Data.Models.House> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<Philter.Aura.Data.Models.House> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<HouseDtoGen>> Save(
            [FromForm] HouseDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Philter.Aura.Data.Models.House> dataSource,
            IBehaviors<Philter.Aura.Data.Models.House> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<HouseDtoGen>> Delete(
            int id,
            IBehaviors<Philter.Aura.Data.Models.House> behaviors,
            IDataSource<Philter.Aura.Data.Models.House> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
