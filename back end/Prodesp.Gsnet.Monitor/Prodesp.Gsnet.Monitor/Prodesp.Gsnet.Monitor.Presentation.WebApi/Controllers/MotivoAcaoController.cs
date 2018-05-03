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
using Prodesp.Gsnet.Monitor.Domain;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.Requests;

namespace Prodesp.Gsnet.Monitor.Presentation.WebApi.Controllers
{
    public class MotivoAcaoController : BaseController<MotivoAcao, MotivoAcaoViewModel, IMotivoAcaoAppService>
    {
        public MotivoAcaoController(IMotivoAcaoAppService service, IEntityTypeConverter<MotivoAcao, MotivoAcaoViewModel> entityConverter, IUnitOfWork unitOfWork)
            : base(service, entityConverter, unitOfWork)
        {
        }        
        [HttpGet]
        [Route("api/motivoacao/tipo/{id}")]
        public IEnumerable<object> BuscarPorTipo(MotivoAcaoEnum id)
        {
            var result = this._service.BuscarPorTipo(id);
            return result.Select(x => new { x.Id, x.Nome, PodeEditarJustificativa = x.PodeEditarJustificativa == 1, JustificativaObrigatoria = x.JustificativaObrigatoria == 1});
        }
        [HttpPost]
        [Route("api/motivoacao/queryitens")]
        public override HttpResponseMessage Query(SearchRequest request)
        {
            return base.Query(request);
        }

    }
}
