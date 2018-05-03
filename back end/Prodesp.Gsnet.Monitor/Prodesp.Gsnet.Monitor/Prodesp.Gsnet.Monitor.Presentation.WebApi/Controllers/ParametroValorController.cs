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
    public class ParametroValorController : BaseController<ParametroValor, ParametroValorViewModel, IParametroValorAppService>
    {


        public ParametroValorController(IParametroValorAppService service, IEntityTypeConverter<ParametroValor, ParametroValorViewModel> entityConverter, IUnitOfWork unitOfWork)
            : base(service, entityConverter, unitOfWork)
        { }

        [HttpPost]
        [Route("api/parametrovalor/queryitens")]
        public override HttpResponseMessage Query(SearchRequest request)
        {
            return base.Query(request);
        }
        // GET: Parametro

        [HttpGet]
        [Route("api/parametrovalor/Listagemparametros")]
        public IEnumerable<ParametroValor> Listagemparametros()
        {
            return this._service.BuscarTodos().ToList();
        }


        [HttpPost]
        [Route("api/parametrovalor/InserirDadosRegraParametroValor")]
        public HttpResponseMessage InserirDadosRegraParametroValor([FromBody] ParametroDTO Dados)
        {
            try
            {
                var resultado = _service.InserirDados(Dados); // edita e depois insere o parametro
                this._unitOfWork.Save();
            }
            catch (Exception ex)
            {
                string ret = ex.Message;
            }
            return OK();
        }
        [HttpGet]
        [Route("api/parametrovalor/retDadosViewDetalheConsumo/{IdRegraMotor}")]
        public HttpResponseMessage retDadosViewDetalheConsumo(int IdRegraMotor)
        {
            try
            {
                var detalhes = new DadosViewDetalheConsumo();
                var dados = this._service.BuscarTodos().Where(x => x.IdRegraMotor == IdRegraMotor).ToList();

                var query = (from item in dados
                            select new DadosViewDetalheConsumo
                            {
                                Id = item.IdParametroValor,
                                IdRegraMotor = item.IdRegraMotor,
                                NomeParametro = item.Parametro.DsParametro,
                                ValorParametro = item.VlParametro
                            }).ToList();


                // var dados = this._service.retDadosViewDetalheConsumo().ToList();
                return ToJson(query) ;
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                return null;
            }

        }
    }
}