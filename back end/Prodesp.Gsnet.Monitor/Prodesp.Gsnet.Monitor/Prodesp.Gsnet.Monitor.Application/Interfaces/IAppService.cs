using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Application.Interfaces
{
    public interface IAppService<TEntity> : IValidation<TEntity>
    {
        ValidationResult Adicionar(TEntity entity);
        ValidationResult Atualizar(TEntity entity);
        ValidationResult Apagar(TEntity entity);
        SearchResult<TEntity> BuscaAvancada(Expression<Func<TEntity, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0);
        TEntity BuscarPorId(int id);
        IEnumerable<TEntity> BuscarTodos();       
        Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> condition);
        Task<TEntity> BuscarPorIdAsync(int id);
        Task<IEnumerable<TEntity>> BuscarTodosAsync();
    }
}
