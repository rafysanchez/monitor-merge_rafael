using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Implementacoes.Domain.Servicos;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;

namespace Prodesp.Gsnet.Monitor.Application.Implementacoes
{
    public class UsuarioAppService : AppService<Usuario, IUsuarioService>
    {
        public UsuarioAppService(IUsuarioService service) : base(service)
        {
        }

        public override ValidationResult ValidarAdicicao(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarAtualizacao(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarRemocao(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
