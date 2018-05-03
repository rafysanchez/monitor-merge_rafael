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
using Prodesp.Gsnet.Monitor.Domain.DTO;

namespace Prodesp.Gsnet.Monitor.Presentation.WebApi.Controllers
{
    public class JustificativaController : BaseController<Justificativa, JustificativaViewModel, IJusticativaAppService>
    {
        IEntityTypeConverter<MotivoAcao, MotivoAcaoViewModel> _motivoAcaoConverter;
        IEntityTypeConverter<HistoricoJustificativaDTO, ListHistoricoJustificativaViewModel> _historicoConverter;
        public JustificativaController(IJusticativaAppService service,
            IEntityTypeConverter<Justificativa, JustificativaViewModel> entityConverter,
            IEntityTypeConverter<MotivoAcao, MotivoAcaoViewModel> motivoAcaoConverter,
            IEntityTypeConverter<HistoricoJustificativaDTO, ListHistoricoJustificativaViewModel> historicoConverter,
            IUnitOfWork unitOfWork) : base(service, entityConverter, unitOfWork)
        {
            _motivoAcaoConverter = motivoAcaoConverter;
            _historicoConverter = historicoConverter;
        }
        [HttpGet]
        [Route("api/justificativa/BuscarPorItem/{id}/{idItem}")]
        public HttpResponseMessage BuscarPorItem(int id, int idItem)
        {
            var justificativa = this._service.BuscarPorItemMonitoramento(id, idItem);
            var result = this._entityConverter.ToViewModel(justificativa ?? new Justificativa());
            return ToJson(result);
        }
        [HttpGet]
        [Route("api/justificativa/BuscarUltimasJustificativas/{id}/{idItem}/{idGestor}")]
        public HttpResponseMessage BuscarUltimasJustificativas(int id, int idItem,int idGestor)
        {
            var itens = this._service.BuscarUltimasJustificativas(id, idItem,idGestor);
            var result = this._entityConverter.ToViewModel(itens);
            return ToJson(result);
        }
        [HttpGet]
        [Route("api/justificativa/historico/{idPrograma}/{idItem}/{idGestor}")]
        public virtual HttpResponseMessage Historico(int idPrograma, int idItem, int idGestor)
        {
            var historico = this._service.BuscarHistoricoJustificativas(idPrograma, idItem,idGestor);
            return ToJson(this._historicoConverter.ToViewModel(historico));
        }
        [HttpPost]
        [Route("api/justificativa/justificar")]
        public virtual HttpResponseMessage Justificar([FromBody]JustificativaViewModel entity)
        {
            return base.Post(entity);
        }
        [HttpPost]
        [Route("api/justificativa/usarAnterior")]
        public virtual HttpResponseMessage UsarAnterior([FromBody]JustificativaViewModel viewModel)
        {
            var entity = this._entityConverter.ToDomainEntity(viewModel);
            var result = this._service.UsarJustificativaAnterior(entity);
            return Save(result);
        }
        [HttpPost]
        [Route("api/justificativa/UsarJustificativaAnterior")]
        public HttpResponseMessage UsarJustificativaAnterior(JustificarVariosRequest param)
        {
            IEnumerable<Justificativa> justificativas = this.CriarColecaoJustificativas(param);
            var result = this._service.UsarJustificativaAnterior(justificativas);
            return Save(result);
        }
        [HttpPost]
        [Route("api/justificativa/justificarvarios")]
        public HttpResponseMessage JustificarVarios(JustificarVariosRequest param)
        {

            var justificativas = this.CriarColecaoJustificativas(param);

            var result = this._service.AdicionarVarios(justificativas);

            return Save(result);
        }
        [HttpPost]
        [Route("api/justificativa/justificarPorPrograma")]
        public HttpResponseMessage JustificarPorPrograma(JustificarPorProgramaRequest param)
        {
            var result = this._service
                            .JustificarPorPrograma(param.Data.IdPrograma,
                                                   param.Data.IdJustificador,
                                                   this._motivoAcaoConverter.ToDomainEntity(param.Data.Motivo),
                                                   this._motivoAcaoConverter.ToDomainEntity(param.Data.Acao));


            return Save(result);
        }
        [HttpPost]
        [Route("api/justificativa/deletarvarios")]
        public HttpResponseMessage DeletarVarios(JustificarVariosRequest param)
        {

            var justificativas = this.CriarColecaoJustificativas(param);

            var result = this._service.DeletarVarios(justificativas);

            return Save(result);
        }



        private IEnumerable<Justificativa> CriarColecaoJustificativas(JustificarVariosRequest param)
        {
            IList<Justificativa> justificativas = new List<Justificativa>();
            foreach (var item in param.Itens)
            {
                justificativas.Add(new Justificativa
                {
                    IdItemMonitoramento = item.IdItemMonitoramento,
                    IdItemGsnet = item.IdItemGsnet,
                    IdGestorMonitor = item.IdGestorMonitor,
                    IdMotivo = param.IdMotivo,
                    MotivoJustificativa = param.MotivoJustificativa,
                    IdAcao = param.IdAcao,
                    AcaoJustificativa = param.AcaoJustificativa,
                    IdJustificador = param.IdJustificador,
                    DataInclusao = DateTime.Now,
                    DataJustificativa = DateTime.Today
                });
            }
            return justificativas;
        }
    }
}
