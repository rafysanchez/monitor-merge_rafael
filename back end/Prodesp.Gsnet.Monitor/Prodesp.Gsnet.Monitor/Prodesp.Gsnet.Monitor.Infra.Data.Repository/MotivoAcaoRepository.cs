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
    public class MotivoAcaoRepository : EFRepository<MotivoAcao>, IMotivoAcaoRepository
    {
        public MotivoAcaoRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public IEnumerable<MotivoAcao> BuscarPorTipo(MotivoAcaoEnum tipo)
        {
            short codigoTipo = (short)tipo;
            var query = this._contexto.MotivosAcoes.Where(x => x.Tipo == codigoTipo).OrderBy(o => o.Nome).ToList();
            return query;
        }
    }
}
