using Castle.DynamicLinqQueryBuilder;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Prodesp.Gsnet.Core.TO.Request;
using Prodesp.Gsnet.Core.TO.Response;
using Prodesp.Gsnet.Monitor.Application.Interfaces;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.Requests;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.Response;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.CrossCutting;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Presentation.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Prodesp.Gsnet.Monitor.Presentation.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
   
    public class BaseController<TEntity, TViewModel, TAppService> : ApiController
        where TEntity : class
        where TAppService : IAppService<TEntity>
        where TViewModel : class

    {
        protected TAppService _service;
        protected IUnitOfWork _unitOfWork;
        protected IEntityTypeConverter<TEntity, TViewModel> _entityConverter;
        public BaseController(TAppService service, IEntityTypeConverter<TEntity, TViewModel> entityConverter, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _service = service;
            _entityConverter = entityConverter;
        }
        [HttpGet]
        public virtual async Task<HttpResponseMessage> Get()
        {
            var result = await _service.BuscarTodosAsync();
            return ToJson(_entityConverter.ToViewModel(result));
        }
        [HttpGet]
        public virtual HttpResponseMessage Get(int id)
        {
            var result = _service.BuscarPorId(id);
            return ToJson(_entityConverter.ToViewModel(result));
        }
        [HttpPost]
        public virtual HttpResponseMessage Post([FromBody]TViewModel entity)
        {
            var result = _service.Adicionar(_entityConverter.ToDomainEntity(entity));
            return Save(result);

        }
        protected string MontarDefinicoesFiltro()
        {
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            string definicao =
               JsonConvert.SerializeObject(typeof(TEntity).GetDefaultColumnDefinitionsForType(false), jsonSerializerSettings);
            return definicao;
        }       
        [HttpPut]
        public virtual HttpResponseMessage Put([FromBody]TViewModel entity)
        {
            var result = _service.Atualizar(_entityConverter.ToDomainEntity(entity));
            return Save(result);
        }
        protected HttpResponseMessage OK()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
        protected HttpResponseMessage OK(dynamic obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return response;
        }
        protected HttpResponseMessage InternalError(string message)
        {
            var response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            response.Content = new StringContent(message, Encoding.UTF8, "application/json");
            return response;
        }
        protected HttpResponseMessage ToJson(dynamic obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return response;
        }
        protected HttpResponseMessage Save(ValidationResult result)
        {
            if (result.IsValid)
            {
                result = this._unitOfWork.Save();
                if (result.IsValid)
                    return OK();
            }
            return InternalError(result.ToString());

        }
        [HttpPost]
        [Route("query")]
        public virtual HttpResponseMessage Query(SearchRequest request)
        {
            var expression = QueryBuilder.BuildQueryExpression<TEntity>(request.Filter, false, null);
            var result = this.QueryItens(request);
            var response = new SearchResult<TViewModel>
            {
                Itens = this._entityConverter.ToViewModel(result.Itens),
                RecordsPerPage = result.RecordsPerPage,
                PageNumber = result.PageNumber,
                TotalRecords = result.TotalRecords,
                TotalPages = (result.TotalRecords > 0 && result.TotalRecords <= result.RecordsPerPage) ? 1 : (int)Math.Ceiling((double)result.TotalRecords / result.RecordsPerPage)
            };
            return ToJson(response);
        }
        protected virtual SearchResult<TEntity> QueryItens(SearchRequest request)
        {
            var expression = QueryBuilder.BuildQueryExpression<TEntity>(request.Filter, false, null);
            return this._service.BuscaAvancada(expression, request.OrderBy, request.SortDirection, (request.RecordsPerPage * request.PageNumber), ((request.PageNumber - 1) * request.RecordsPerPage));

        }
        protected override void Dispose(bool disposing)
        {

            this._unitOfWork.Dispose(disposing);
            base.Dispose(disposing);
        }

        protected HttpResponseMessage CreateResponse<TResponse>(TResponse obj, HttpStatusCode statusCode) where TResponse : IResponseBase
        {
            var response = Request.CreateResponse(statusCode);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return response;
        }
        protected HttpResponseMessage OK<TResponse>(TResponse obj) where TResponse : IResponseBase
        {
            return this.CreateResponse(obj, HttpStatusCode.OK);
        }
    }
}
