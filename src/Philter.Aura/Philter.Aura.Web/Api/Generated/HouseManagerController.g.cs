
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
    [Route("api/HouseManager")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class HouseManagerController
        : BaseApiController<Philter.Aura.Data.Models.HouseManager, HouseManagerDtoGen, Philter.Aura.Data.AuraDbContext>
    {
        public HouseManagerController(CrudContext<Philter.Aura.Data.AuraDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Philter.Aura.Data.Models.HouseManager>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<HouseManagerDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<Philter.Aura.Data.Models.HouseManager> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<HouseManagerDtoGen>> List(
            ListParameters parameters,
            IDataSource<Philter.Aura.Data.Models.HouseManager> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<Philter.Aura.Data.Models.HouseManager> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<HouseManagerDtoGen>> Save(
            [FromForm] HouseManagerDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Philter.Aura.Data.Models.HouseManager> dataSource,
            IBehaviors<Philter.Aura.Data.Models.HouseManager> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<HouseManagerDtoGen>> Delete(
            int id,
            IBehaviors<Philter.Aura.Data.Models.HouseManager> behaviors,
            IDataSource<Philter.Aura.Data.Models.HouseManager> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
