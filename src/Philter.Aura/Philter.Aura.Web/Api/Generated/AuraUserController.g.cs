
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
    [Route("api/AuraUser")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class AuraUserController
        : BaseApiController<Philter.Aura.Data.Models.AuraUser, AuraUserDtoGen, Philter.Aura.Data.AuraDbContext>
    {
        public AuraUserController(CrudContext<Philter.Aura.Data.AuraDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Philter.Aura.Data.Models.AuraUser>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<AuraUserDtoGen>> Get(
            System.Guid id,
            DataSourceParameters parameters,
            IDataSource<Philter.Aura.Data.Models.AuraUser> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<AuraUserDtoGen>> List(
            ListParameters parameters,
            IDataSource<Philter.Aura.Data.Models.AuraUser> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<Philter.Aura.Data.Models.AuraUser> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<AuraUserDtoGen>> Save(
            [FromForm] AuraUserDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Philter.Aura.Data.Models.AuraUser> dataSource,
            IBehaviors<Philter.Aura.Data.Models.AuraUser> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<AuraUserDtoGen>> Delete(
            System.Guid id,
            IBehaviors<Philter.Aura.Data.Models.AuraUser> behaviors,
            IDataSource<Philter.Aura.Data.Models.AuraUser> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
