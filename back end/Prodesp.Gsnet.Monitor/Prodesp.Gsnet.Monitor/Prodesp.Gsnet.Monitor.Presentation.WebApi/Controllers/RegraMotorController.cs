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
using Prodesp.Gsnet.Framework;

namespace Prodesp.Gsnet.Monitor.Presentation.WebApi.Controllers
{
    public class RegraMotorController : BaseController<RegraMotor, RegraMotorViewModel, IRegraMotorAppService>
    {
        IParametroValorAppService _iParametroValorAppService;
        public RegraMotorController(IRegraMotorAppService service, IEntityTypeConverter<RegraMotor, RegraMotorViewModel> entityConverter, IUnitOfWork unitOfWork, IParametroValorAppService iParametroValorAppService)
            : base(service, entityConverter, unitOfWork)
        {
            _iParametroValorAppService = iParametroValorAppService;
        }

        [HttpPost]
        [Route("api/regramotor/queryitens")]
        public override HttpResponseMessage Query(SearchRequest request)
        {
            var dados = base.Query(request);
            return dados;
        }

        [HttpGet]
        [Route("api/regramotor/listar")]
        public HttpResponseMessage listar()
        {
            var result = this._service.BuscarTodos();

            return ToJson(result);
        }

        [HttpGet]
        [Route("api/regramotor/ListCombo")]
        public IEnumerable<ComboTipoViewModel> ListCombo()
        {
            var dados = this._service.BuscarTodos().ToList();

            var query = (from itens in dados
                             //where itens.IdRegraMotor==3
                         select new ComboTipoViewModel
                         {
                             Id = itens.IdRegraMotor,
                             Tipo = itens.TpParametro,
                             Descricao = desc(itens.TpParametro)
                         });


            return query;
        }

        string desc(int tipo)
        {
            string retorno;
            retorno = tipo == 1 ? "Autonomia Consumo" : "Saldo Zerado";
            return retorno;
        }
        [HttpPost]
        [Route("api/regramotor/InserirDadosRegraParametroValor")]
        public HttpResponseMessage InserirDadosRegraParametroValor([FromBody] ParametroDTO Dados)
        {
            try
            {
                var resultadoRegra = _service.InserirDados(Dados); // edita e depois insere o parametro
                Dados.IdRegraMotor = resultadoRegra.IdRegraMotor;
                var resultadoParametro = _iParametroValorAppService.InserirDados(Dados);
                var ret = this._unitOfWork.Save();
            }
            catch (Exception ex)
            {
                string ret = ex.Message;
            }
            return OK();
        }

        [HttpPost]
        [Route("api/regramotor/EditarDadosRegraParametroValor")]
        public HttpResponseMessage EditarDadosRegraParametroValor([FromBody] ParametroDTO Dados)
        {
            try
            {
                var ObjNovaRegra = new RegraMotor();
                var ObjRegraAtual = _service.BuscarPorId(Dados.IdRegraMotor);

                if (ObjRegraAtual.DataInicioVigencia <= DateTime.Now && ObjRegraAtual.FlStatus.Equals('S') && ObjRegraAtual.FlagAtivo.Equals('N'))
                {
                    ObjRegraAtual.FlStatus.Equals('N');
                    ObjRegraAtual.DataFimVigencia = DateTime.Now;
                    ObjRegraAtual.IdUsuario = 0;
                    _service.Atualizar(ObjRegraAtual);
                    var ret = this._unitOfWork.Save();
                }
                else
                {
                    if (ObjRegraAtual.DataInicioVigencia > DateTime.Now && ObjRegraAtual.FlStatus.Equals('S'))
                    {
                        // atualização de dados

                        ObjRegraAtual.FlStatus.Equals('N');
                        ObjRegraAtual.DataFimVigencia = DateTime.Now;
                        _service.Atualizar(ObjRegraAtual);

                        // insercao de dados em regra motor
                        ObjNovaRegra.TpParametro = Convert.ToInt16(Dados.Tipo);
                        ObjNovaRegra.IdUsuario = 0;
                        ObjNovaRegra.IdProgramaMotor = Dados.IdProgramaMonitor;
                        ObjNovaRegra.DataInicioVigencia = Convert.ToDateTime(Dados.DtInicial);
                        ObjNovaRegra.DataFimVigencia = Convert.ToDateTime(Dados.DtFinal);
                        ObjNovaRegra.FlagAtivo = "N";
                        ObjNovaRegra.FlStatus = "S";
                        var ret = this._unitOfWork.Save();
                    }

                }

                return OK();

            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Atualização invalida");
            }

        }

        [HttpGet]
        [Route("api/regramotor/GetByIdDadosAEditar/{id}")]
        public HttpResponseMessage GetById(int Id)
        {
            try
            {
                var objParametroDTO = new ParametroDTO();
                var dadosRegra = this._service.BuscarTodos().Where(x => x.IdRegraMotor == Id).SingleOrDefault();
                var dadosParametroValor = this._iParametroValorAppService.BuscarTodos().Where(x => x.IdRegraMotor == Id).ToList();

                objParametroDTO.IdRegraMotor = dadosRegra.IdRegraMotor;
                objParametroDTO.IdProgramaMonitor = dadosRegra.IdProgramaMotor;
                objParametroDTO.DtInicial = dadosRegra.DataInicioVigencia.ToShortDateString();


                var ac = dadosRegra.DataFimVigencia.ToString();
                if (ac != string.Empty) { ac = ac.Substring(0, 10); }
                objParametroDTO.DtFinal = ac;


                objParametroDTO.FlagAtivo = dadosRegra.FlagAtivo;

                // dados parametro valor
                objParametroDTO.QtdeMeses = dadosParametroValor.Where(d => d.IdParametro == 9).SingleOrDefault().VlParametro;
                objParametroDTO.Apresentacao = dadosParametroValor.Where(d => d.IdParametro == 5).SingleOrDefault().VlParametro;
                objParametroDTO.Autonomia = dadosParametroValor.Where(d => d.IdParametro == 5).SingleOrDefault().VlParametro;
                objParametroDTO.ConsumoMensal = dadosParametroValor.Where(d => d.IdParametro == 6).SingleOrDefault().VlParametro;
                objParametroDTO.FormulaCalculo = dadosParametroValor.Where(d => d.IdParametro == 7).SingleOrDefault().VlParametro;

                return ToJson(objParametroDTO);
            }
            catch (Exception)
            {

                return ToJson(new ParametroDTO());
            }

        }
    }
}