using Prodesp.Gsnet.Monitor.Application.Interfaces;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Domain;

namespace Prodesp.Gsnet.Monitor.Application.Implementacoes
{
    public class ProgramaSaudeAppService : AppService<ProgramaSaude, IProgramaSaudeService>, IProgramaSaudeAppService
    {

        public ProgramaSaudeAppService(IProgramaSaudeService service) : base(service)
        {
        }

        public override ValidationResult ValidarAdicicao(ProgramaSaude entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarAtualizacao(ProgramaSaude entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarRemocao(ProgramaSaude entity)
        {
            throw new NotImplementedException();
        }
    }
}
