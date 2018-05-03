using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Application.Interfaces
{
    public interface IItemMonitoramentoAppService : IAppService<ItemMonitoramento>
    {
        IEnumerable<ItemMonitoramentoDTO> BuscarPorMonitoramento(int idMonitoramento);
        SearchResult<ItemMonitoramentoDTO> Buscar(Expression<Func<ItemMonitoramentoDTO, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0);
    }
}
