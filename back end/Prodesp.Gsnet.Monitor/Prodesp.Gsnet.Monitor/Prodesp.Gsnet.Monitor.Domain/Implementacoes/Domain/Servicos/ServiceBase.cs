using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Prodesp.Gsnet.Monitor.Domain.Entidades;

namespace Prodesp.Gsnet.Monitor.Domain.Implementacoes.Domain.Servicos
{
    public class ServiceBase<TEntity, TRepository> : IService<TEntity>
        where TEntity : class
        where TRepository : IRepository<TEntity>
    {
        public TRepository _repository;
        public ServiceBase(TRepository repository)
        {
            _repository = repository;
        }

        public void Adicionar(TEntity entity)
        {
            _repository.Adicionar(entity);
        }

        public void Apagar(TEntity entity)
        {
            _repository.Apagar(entity);
        }

        public void Atualizar(TEntity entity)
        {
            _repository.Atualizar(entity);
        }

        public SearchResult<TEntity> BuscaAvancada(Expression<Func<TEntity, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0)
        {
            return _repository.BuscaAvancada(condition, orderBy, sortDirection, take, skip);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0)
        {
            return _repository.Buscar(condition, orderBy, sortDirection, take, skip);
        }

        public async Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await _repository.BuscarAsync(condition);
        }

        public TEntity BuscarPorId(int id)
        {
            return _repository.BuscarPorId(id);
        }

        public async Task<TEntity> BuscarPorIdAsync(int id)
        {
            return await _repository.BuscarPorIdAsync(id);
        }

        public IEnumerable<TEntity> BuscarTodos()
        {
            return _repository.BuscarTodos();
        }

        public async Task<IEnumerable<TEntity>> BuscarTodosAsync()
        {
            return await _repository.BuscarTodosAsync();
        }
    }
}
