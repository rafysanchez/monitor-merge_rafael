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
    public class MotivoAcaoService : ServiceBase<MotivoAcao, IMotivoAcaoRepository>, IMotivoAcaoService
    {
        public MotivoAcaoService(IMotivoAcaoRepository repository) : base(repository)
        {
        }

        public IEnumerable<MotivoAcao> BuscarPorTipo(MotivoAcaoEnum tipo)
        {
            return this._repository.BuscarPorTipo(tipo);
        }
    }
}
