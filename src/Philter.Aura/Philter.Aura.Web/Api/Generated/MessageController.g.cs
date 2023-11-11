
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
    [Route("api/Message")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class MessageController
        : BaseApiController<Philter.Aura.Data.Models.Message, MessageDtoGen, Philter.Aura.Data.AuraDbContext>
    {
        public MessageController(CrudContext<Philter.Aura.Data.AuraDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Philter.Aura.Data.Models.Message>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<MessageDtoGen>> Get(
            long id,
            DataSourceParameters parameters,
            IDataSource<Philter.Aura.Data.Models.Message> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<MessageDtoGen>> List(
            ListParameters parameters,
            IDataSource<Philter.Aura.Data.Models.Message> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<Philter.Aura.Data.Models.Message> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<MessageDtoGen>> Save(
            [FromForm] MessageDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Philter.Aura.Data.Models.Message> dataSource,
            IBehaviors<Philter.Aura.Data.Models.Message> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [Authorize]
        public virtual Task<ItemResult<MessageDtoGen>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<MessageDtoGen>> Delete(
            long id,
            IBehaviors<Philter.Aura.Data.Models.Message> behaviors,
            IDataSource<Philter.Aura.Data.Models.Message> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
