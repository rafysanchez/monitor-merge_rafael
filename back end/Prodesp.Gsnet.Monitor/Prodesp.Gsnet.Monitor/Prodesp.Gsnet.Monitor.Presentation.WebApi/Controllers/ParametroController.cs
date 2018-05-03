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
using Prodesp.Gsnet.Monitor.Domain.DTO;

namespace Prodesp.Gsnet.Monitor.Presentation.WebApi.Controllers
{
    public class ParametroController : BaseController<Parametro, ParametroViewModel, IParametroAppService>
    {
        public ParametroController(IParametroAppService service, IEntityTypeConverter<Parametro, ParametroViewModel> entityConverter, IUnitOfWork unitOfWork)
            : base(service, entityConverter, unitOfWork)
        {
        }   
        // GET: Parametro
        [HttpPost]
        [Route("api/parametro/ListagemGridParametros")]
        public IEnumerable<Parametro> ListagemGridParametros()
        {
            return this._service.BuscarTodos().ToList();
        }
        [HttpPost]
        [Route("api/parametro/queryitens")]
        public override HttpResponseMessage Query(SearchRequest request)
        {
            var dados = base.Query(request);
            return dados;
        }



        

    }
}