using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Prodesp.Gsnet.Monitor.Domain.Entidades;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios
{
    public abstract class ARepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public readonly IUnitOfWork _unitOfWork;
        public ARepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public abstract void Adicionar(TEntity entity);

        public abstract void Apagar(TEntity entity);

        public abstract void Atualizar(TEntity entity);

        public SearchResult<TEntity> BuscaAvancada(Expression<Func<TEntity, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0)
        {
            throw new NotImplementedException();
        }

        public abstract IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> condition);

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> condition, string orderBy = "", string sortDirection = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0)
        {
            throw new NotImplementedException();
        }

        public abstract Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> condition);

        public abstract TEntity BuscarPorId(int id);

        public abstract Task<TEntity> BuscarPorIdAsync(int id);

        public abstract IEnumerable<TEntity> BuscarTodos();

        public abstract Task<IEnumerable<TEntity>> BuscarTodosAsync();

        public IQueryable<TEntity> Queryable()
        {
            throw new NotImplementedException();
        }
    }
}
