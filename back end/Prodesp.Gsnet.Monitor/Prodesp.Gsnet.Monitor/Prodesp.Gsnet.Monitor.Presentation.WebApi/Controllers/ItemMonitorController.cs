using Prodesp.Gsnet.Monitor.Application.Interfaces;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.CrossCutting;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Core.TO.Request;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios;
using Prodesp.Gsnet.Monitor.CrossCutting.Data;
using Castle.DynamicLinqQueryBuilder;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.Requests;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.Response;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;

namespace Prodesp.Gsnet.Monitor.Presentation.WebApi.Controllers
{
    public class ItemMonitorController : BaseController<ItemMonitoramento, ItemMonitoramentoViewModel, IItemMonitoramentoAppService>
    {
        IItemMonitoramentoRepository _repository;
        IIndicadoresMonitoramentoService _indicadoresService;
        IEntityTypeConverter<IndicadoresMonitoramento, IndicadoresViewModel> _indicadoresConverter;
        IEntityTypeConverter<ItemMonitoramentoDTO, ItemAlertaMonitorViewModel> _itemConverter;
        public ItemMonitorController(IItemMonitoramentoAppService service,
            IEntityTypeConverter<ItemMonitoramento,
            ItemMonitoramentoViewModel> entityConverter,
            IEntityTypeConverter<IndicadoresMonitoramento, IndicadoresViewModel> indicadoresConverter,
            IEntityTypeConverter<ItemMonitoramentoDTO, ItemAlertaMonitorViewModel> itemConverter,
            IIndicadoresMonitoramentoService indicadoresService,            
            IUnitOfWork unitOfWork, IItemMonitoramentoRepository repository)
            : base(service, entityConverter, unitOfWork)
        {
            _repository = repository;
            _indicadoresService = indicadoresService;
            _itemConverter = itemConverter;
        }
        [HttpGet]
        public IEnumerable<ItemMonitoramentoDTO> BuscarPorMonitoramento(int id)
        {

            return this._service.BuscarPorMonitoramento(id);
        }
        [HttpPost]
        [Route("api/itemmonitor/queryitens")]
        public override HttpResponseMessage Query(SearchRequest request)
        {
            ItemMonitoramentoResponse response = new ItemMonitoramentoResponse();

            var expression = QueryBuilder.BuildQueryExpression<ItemMonitoramentoDTO>(request.Filter, false, null);
            var result = this._service.Buscar(expression, request.OrderBy, request.SortDirection, request.RecordsPerPage * request.PageNumber, ((request.PageNumber - 1) * request.RecordsPerPage));

            if ((result?.Itens.Any()).GetValueOrDefault())
            {
                response = result.Itens.GroupBy(x => new { x.DataMonitoramento, x.IdPrograma }, (g, itens) => new ItemMonitoramentoResponse
                {
                    DataMonitoramento = g.DataMonitoramento.ToShortDateString(),
                    IdPrograma = g.IdPrograma.GetValueOrDefault(),
                    Data = _itemConverter.ToViewModel(itens).ToList(),
                    TotalRecords = result.TotalRecords,
                    TotalPages = (result.TotalRecords > 0 && result.TotalRecords <=result.RecordsPerPage) ? 1 : (int)Math.Ceiling((double)result.TotalRecords / result.RecordsPerPage)
                }).Single();
                DateTime dataMonitoramento = Convert.ToDateTime(response.DataMonitoramento);
                var resumo = this._indicadoresService.Buscar(x => x.DataMonitoramento == dataMonitoramento && x.Id == response.IdPrograma).FirstOrDefault();
                response.JustificativasPendentes = resumo.JustificativasPendentes;
                response.NomePrograma = resumo.NomePrograma;
                response.QuantidadeAlertas = resumo.QuantidadeAlertas;
                response.QuantidadeAlertasItens = resumo.QuantidadeAlertasItens;
                response.QuantidadeItens = resumo.QuantidadeItens;
                response.TipoConsumoAutonomia = resumo.TipoConsumoAutonomia;
                response.TipoConsumoSaldoZerado = resumo.TipoConsumoSaldoZerado;
                response.Percentual = $"{((resumo.QuantidadeAlertasItens * 100) / resumo.QuantidadeItens)} %";                
            }
            return ToJson(response);
        }
        private string DecodeTipoConsumo(short? tipoConsumo)
        {
            switch (tipoConsumo)
            {
                case 1:
                    return "Consumo Médio Mensal"; ;
                case 2:
                    return "Maior Consumo";
                case 3:
                    return "Menor Consumo";
                case 4:
                    return "Ultimo Consumo";
                default:
                    return string.Empty;
            }
        }
    }
}
