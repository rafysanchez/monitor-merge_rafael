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
    public class ProgramaSaudeController : BaseController<ProgramaSaude, ProgramaSaudeViewModel, IProgramaSaudeAppService>
    {
        public ProgramaSaudeController(IProgramaSaudeAppService service, IEntityTypeConverter<ProgramaSaude, ProgramaSaudeViewModel> entityConverter, IUnitOfWork unitOfWork)
            : base(service, entityConverter, unitOfWork)
        {
        }

        
        [HttpPost]
        [Route("api/programasaude/queryitens")]
        public override HttpResponseMessage Query(SearchRequest request)
        {
            return base.Query(request);
        }

        [HttpGet]
        [Route("api/programasaude/ListarProgramasSaude")]
        public IEnumerable<ProgramaSaude> ListarProgramasSaude()
        {
            var dadosCombo = this._service.BuscarTodos().ToList().OrderBy(y=>y.NomePrograma);
           
            return dadosCombo;
        }

    }
}
