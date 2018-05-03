using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios
{
    public interface IItemMonitoramentoRepository : IRepository<ItemMonitoramento>
    {
        IEnumerable<ItemMonitoramentoDTO> BuscarPorMonitoramento(int idMonitoramento);
        IEnumerable<ItemMonitoramentoDTO> BuscarPorPrograma(int idPrograma);
        SearchResult<ItemMonitoramentoDTO> Buscar(Expression<Func<ItemMonitoramentoDTO, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0);

    }
}
