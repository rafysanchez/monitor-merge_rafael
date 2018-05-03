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
    public class RegraMotorRepository : EFRepository<RegraMotor>, IRegraMotorRepository
    {
        public RegraMotorRepository(IUnitOfWork uow) : base(uow)
        {

        }
        RegraMotor IRegraMotorRepository.InserirDados(ParametroDTO dadoRec)
        {
            var DadoRegra = new RegraMotor();
            try
            {
                // cadastrar novo
                // add TABELA MON_REGRA_MOTOR 

               
                DadoRegra.IdProgramaMotor = Convert.ToInt32(dadoRec.IdProgramaMonitor);
                DadoRegra.TpParametro = Convert.ToInt16(dadoRec.Tipo);
                DadoRegra.IdUsuario = 0;
                DadoRegra.DataInicioVigencia =Convert.ToDateTime( dadoRec.DtInicial);
                DadoRegra.DataFimVigencia = Convert.ToDateTime(dadoRec.DtFinal);
                DadoRegra.FlStatus = Convert.ToString('S');
                DadoRegra.FlagAtivo = Convert.ToString('N');

                this._contexto.RegraMotors.Add(DadoRegra);
                var objeto = this._contexto.RegraMotors.Add(DadoRegra);
               // this._contexto.SaveChanges();
                var idNovodeRegra = DadoRegra.IdRegraMotor;
                

                return objeto;
            }
            catch (Exception ex)
            {

                return DadoRegra;
            }
        }
    }
}
