using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain
{
    public interface IEntityInteractions<TEntity>
    {
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0);

        SearchResult<TEntity> BuscaAvancada(Expression<Func<TEntity, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0);

        TEntity BuscarPorId(int id);
        IEnumerable<TEntity> BuscarTodos();
        Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> condition);
        Task<TEntity> BuscarPorIdAsync(int id);
        Task<IEnumerable<TEntity>> BuscarTodosAsync();
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Apagar(TEntity entity);
    }
}
