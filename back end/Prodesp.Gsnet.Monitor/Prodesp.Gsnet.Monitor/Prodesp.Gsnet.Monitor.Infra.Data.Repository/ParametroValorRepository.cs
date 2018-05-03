using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Infra.Data.EF.Implementacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios;
using Prodesp.Gsnet.Monitor.Domain;
using Prodesp.Gsnet.Monitor.Domain.DTO;

namespace Prodesp.Gsnet.Monitor.Infra.Data.Repository
{
   public class ParametroValorRepository : EFRepository<ParametroValor>, IParametroValorRepository
    {
        public ParametroValorRepository(IUnitOfWork uow) : base(uow)
        {

        }
        string IParametroValorRepository.InserirDados(ParametroDTO dadoRec)
        {
            try
            {

                // ADD EM  MON_PARAMETRO VALOR
                // qtde meses
                //int id=0;
                  var dadoMeses = new ParametroValor();

                dadoMeses.IdParametro = 9;
                dadoMeses.IdRegraMotor = dadoRec.IdRegraMotor;
                dadoMeses.VlParametro = dadoRec.QtdeMeses;
                this._contexto.ParametroValors.Add(dadoMeses);

                ////  Autonomia
                var dadosAutonomia = new ParametroValor();

                if (dadoRec.Tipo=="2")
                {
                    dadosAutonomia.IdParametro = 4;
                    dadosAutonomia.IdRegraMotor = dadoRec.IdRegraMotor;
                    dadosAutonomia.VlParametro = dadoRec.Autonomia;
                    this._contexto.ParametroValors.Add(dadosAutonomia);
                }
                

                //// Apresentacao
                var dadosApresentacao = new ParametroValor();
                dadosApresentacao.IdParametro = 5;
                dadosApresentacao.IdRegraMotor = dadoRec.IdRegraMotor;
                dadosApresentacao.VlParametro = dadoRec.Apresentacao;
                this._contexto.ParametroValors.Add(dadosApresentacao);

                //// Consumo mensal maior que zero
                var dadosConsumoMensal = new ParametroValor();
                dadosConsumoMensal.IdParametro = 6;
                dadosConsumoMensal.IdRegraMotor = dadoRec.IdRegraMotor;
                if (dadoRec.ConsumoMensal=="True")
                {dadosConsumoMensal.VlParametro = "1"; }else { dadosConsumoMensal.VlParametro = "2"; }
                this._contexto.ParametroValors.Add(dadosConsumoMensal);

                //// formula de cálculo
                var dadosFormulaCalculo = new ParametroValor();
                dadosFormulaCalculo.IdParametro = 7;
                dadosFormulaCalculo.IdRegraMotor = dadoRec.IdRegraMotor;
                dadosFormulaCalculo.VlParametro = dadoRec.FormulaCalculo;
                this._contexto.ParametroValors.Add(dadosFormulaCalculo);


                return "Dados inseridos com sucesso.";
            }
            catch (Exception ex)
            {

                return "Erro: " + ex.Message;
            }
        }
    }
}
