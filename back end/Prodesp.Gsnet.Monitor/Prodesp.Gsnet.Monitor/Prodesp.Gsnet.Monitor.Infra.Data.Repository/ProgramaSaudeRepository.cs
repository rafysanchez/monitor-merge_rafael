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

namespace Prodesp.Gsnet.Monitor.Infra.Data.Repository
{
   public  class ProgramaSaudeRepository : EFRepository<ProgramaSaude>, IProgramaSaudeRepository
    {
        public ProgramaSaudeRepository(IUnitOfWork uow) : base(uow)
        {
        }



    }
}
