using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Implementacoes.Domain.Servicos
{
   public class RegraMotorService : ServiceBase<RegraMotor, IRegraMotorRepository>, IRegraMotorService
    {

        public RegraMotorService(IRegraMotorRepository repository) : base(repository)
        {
        }

        RegraMotor IRegraMotorService.InserirDados(ParametroDTO dado)
        {
            return this._repository.InserirDados(dado);

        }

    }
}
