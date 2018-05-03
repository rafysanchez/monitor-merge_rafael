using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.DTO;
using System.Linq.Expressions;

namespace Prodesp.Gsnet.Monitor.Domain.Implementacoes.Domain.Servicos
{
    public class ItemMonitoramentoService : ServiceBase<ItemMonitoramento, IItemMonitoramentoRepository>, IItemMonitoramentoService
    {
        public ItemMonitoramentoService(IItemMonitoramentoRepository repository) : base(repository)
        {
        }

        public SearchResult<ItemMonitoramentoDTO> Buscar(Expression<Func<ItemMonitoramentoDTO, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0)
        {
            return this._repository.Buscar(condition, orderBy, sortDirection, take, skip);
        }

        public IEnumerable<ItemMonitoramentoDTO> BuscarPorMonitoramento(int idMonitoramento)
        {
            return this._repository.BuscarPorMonitoramento(idMonitoramento);
        }

        public IEnumerable<ItemMonitoramentoDTO> BuscarPorPrograma(int idPrograma)
        {
            return this._repository.BuscarPorPrograma(idPrograma);
        }
    }
}
