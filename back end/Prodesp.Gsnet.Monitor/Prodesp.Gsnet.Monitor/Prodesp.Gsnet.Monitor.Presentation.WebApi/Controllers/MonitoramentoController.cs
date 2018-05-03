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
using Prodesp.Gsnet.Monitor.CrossCutting.TO.Requests;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.Response;

namespace Prodesp.Gsnet.Monitor.Presentation.WebApi.Controllers
{
    public class MonitoramentoController : BaseController<Monitoramento, MonitoramentoViewModel, IMonitoramentoAppService>
    {
        IIndicadoresMonitoramentoService _indicadoresService;
        IEntityTypeConverter<IndicadoresMonitoramento, IndicadoresViewModel> _indicadoresConverter;
        public MonitoramentoController(
            IMonitoramentoAppService service,
            IEntityTypeConverter<Monitoramento, MonitoramentoViewModel> entityConverter,
            IEntityTypeConverter<IndicadoresMonitoramento, IndicadoresViewModel> indicadoresConverter,
            IIndicadoresMonitoramentoService indicadoresService,
            IUnitOfWork unitOfWork) : base(service, entityConverter, unitOfWork)
        {
            _indicadoresService = indicadoresService;
            _indicadoresConverter = indicadoresConverter;
        }
        [HttpPost]
        public override HttpResponseMessage Query(SearchRequest request)
        {
            IndicadoresResponse response = new IndicadoresResponse();

            //var result = base.QueryItens(request).Select(x=> x.DataMonitoramento).Distinct();

            //if (result != null)
            //{
            //    var resumo = this._indicadoresService.Buscar(x => x.DataMonitoramento == result).FirstOrDefault();
            //    var viewModel = _indicadoresConverter.ToViewModel(resumo);
            //    response.Data = viewModel;
            //}
            return OK(response);
        }
    }
}
