
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Behaviors;
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
    [Route("api/Recipient")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class RecipientController
        : BaseApiController<Philter.Aura.Data.Models.Recipient, RecipientDtoGen, Philter.Aura.Data.AuraDbContext>
    {
        public RecipientController(CrudContext<Philter.Aura.Data.AuraDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Philter.Aura.Data.Models.Recipient>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<RecipientDtoGen>> Get(
            long id,
            DataSourceParameters parameters,
            IDataSource<Philter.Aura.Data.Models.Recipient> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<RecipientDtoGen>> List(
            ListParameters parameters,
            IDataSource<Philter.Aura.Data.Models.Recipient> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<Philter.Aura.Data.Models.Recipient> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<RecipientDtoGen>> Save(
            [FromForm] RecipientDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Philter.Aura.Data.Models.Recipient> dataSource,
            IBehaviors<Philter.Aura.Data.Models.Recipient> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [Authorize]
        public virtual Task<ItemResult<RecipientDtoGen>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<RecipientDtoGen>> Delete(
            long id,
            IBehaviors<Philter.Aura.Data.Models.Recipient> behaviors,
            IDataSource<Philter.Aura.Data.Models.Recipient> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
