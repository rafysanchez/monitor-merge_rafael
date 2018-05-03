using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Repositorios;
using Prodesp.Gsnet.Monitor.Infra.Data.EF.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Implementacoes
{
    public class EFRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        IUnitOfWork _uow;
        public readonly Contexto _contexto;
        public EFRepository(IUnitOfWork uow)//:base(uow)
        {
            _uow = uow;
            _contexto = uow.GetSession() as Contexto;
        }
        public void Adicionar(TEntity entity)
        {
            _contexto.Set<TEntity>().Add(entity);
        }

        public void Apagar(TEntity entity)
        {
            _contexto.Set<TEntity>().Remove(entity);
        }

        public void Atualizar(TEntity entity)
        {
            _contexto.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await _contexto.Set<TEntity>().Where(condition).AsNoTracking().ToListAsync();
        }
        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0)
        {
            var query = _contexto.Set<TEntity>().Where(condition);// 
            if (!string.IsNullOrEmpty(orderBy))
            {
                if (!string.IsNullOrEmpty(sortDirection))
                {
                    if (sortDirection == "asc")
                        query = OrderByHelper.OrderBy(query, orderBy);
                    else
                        query = OrderByHelper.OrderByDescending(query, orderBy);

                    if (take > 0)
                        query = query.Take(take);
                    if (skip > 0)
                        query = query.Skip(skip);
                }

            }
            return query.AsNoTracking().ToList();
        }
        public SearchResult<TEntity> BuscaAvancada(Expression<Func<TEntity, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0)
        {
            var query = _contexto.Set<TEntity>().AsQueryable();

            if (condition != null)
                query = query.Where(condition);

            int totalRecords = query.Count();
            if (!string.IsNullOrEmpty(orderBy))
            {
                if (!string.IsNullOrEmpty(sortDirection))
                {
                    if (sortDirection == "asc")
                        query = OrderByHelper.OrderBy(query, orderBy);
                    else
                        query = OrderByHelper.OrderByDescending(query, orderBy);

                    if (take > 0)
                        query = query.Take(take);
                    if (skip > 0)
                        query = query.Skip(skip);
                }
            }
            return new SearchResult<TEntity>
            {
                Itens = query.ToList(),
                TotalRecords = totalRecords,
                RecordsPerPage = take
            };
        }
        public IEnumerable<TEntity> BuscarTodos()
        {
            return _contexto.Set<TEntity>().AsNoTracking().ToList();
        }
        public async Task<IEnumerable<TEntity>> BuscarTodosAsync()
        {
            return await _contexto.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public TEntity BuscarPorId(int key)
        {
            return _contexto.Set<TEntity>().Find(key);
        }
        public async Task<TEntity> BuscarPorIdAsync(int key)
        {
            return await _contexto.Set<TEntity>().FindAsync(key);
        }

    }
}
