using Prodesp.Gsnet.Monitor.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Domain.Entidades;

namespace Prodesp.Gsnet.Monitor.Application.Implementacoes
{
    /// <summary>
    /// Representa de forma generica as operacoes do sistema e fornece 
    /// metodos para manipulação dos registros da aplicacao
    /// </summary>
    /// <typeparam name="TEntity">Tipo de registro </typeparam>
    /// <typeparam name="TService">Servico que ira realizar as operações no sistema</typeparam>
    public abstract class AppService<TEntity, TService> : IAppService<TEntity>
        where TEntity : class, ISelfValidation
        where TService : IService<TEntity>
    {
        /// <summary>
        /// Servico que controla as operacoes no sistema
        /// </summary>
        public TService _service;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public AppService(TService service)
        {
            _service = service;
        }
        /// <summary>
        /// Adicina um registro no sistema
        /// </summary>
        /// <param name="entity">registro a ser incluido no sistema</param>
        /// <returns>resultado da validacao do registro</returns>
        public virtual ValidationResult Adicionar(TEntity entity)
        {
            ValidationResult validacao = this.Validate(entity);

            return this.ExecutarQuandoForValido(entity, () => this.ValidarAdicicao(entity), () => _service.Adicionar(entity));
        }
        /// <summary>
        /// Apaga um registro do sistema
        /// </summary>
        /// <param name="entity">registro a ser apagado</param>
        /// <returns>resultado da validacao  do registro</returns>
        public virtual ValidationResult Apagar(TEntity entity)
        {
            return this.ExecutarQuandoForValido(entity, () => this.ValidarRemocao(entity), () => _service.Apagar(entity));
        }
        /// <summary>
        /// Atualiza um registro no sistema
        /// </summary>
        /// <param name="entity">registro a ser atualizado</param>
        /// <returns></returns>
        public virtual ValidationResult Atualizar(TEntity entity)
        {
            return this.ExecutarQuandoForValido(entity, () => this.ValidarAtualizacao(entity), () => _service.Atualizar(entity));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0)
        {
            return _service.Buscar(condition,orderBy,sortDirection,take,skip);
        }
        public async Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await _service.BuscarAsync(condition);
        }
        /// <summary>
        /// Buscar um registro atraves do seu codigo identificador
        /// </summary>
        /// <param name="id">Codigo identificador do registro</param>
        /// <returns></returns>
        public virtual TEntity BuscarPorId(int id)
        {
            return _service.BuscarPorId(id);
        }

        public virtual async Task<TEntity> BuscarPorIdAsync(int id)
        {
            return await _service.BuscarPorIdAsync(id);
        }
        /// <summary>
        /// Buscar todos os registros no sistema
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> BuscarTodos()
        {
            return _service.BuscarTodos();
        }
        public virtual async Task<IEnumerable<TEntity>> BuscarTodosAsync()
        {
            return await _service.BuscarTodosAsync();
        }
        /// <summary>
        /// Testa se a entidade atende os requisitos necessário para uma determinada ação do servico, 
        /// executando-o quando for possivel
        /// </summary>
        /// <param name="entity">Entidade na qual a acao sera aplicacada</param>
        /// <param name="validacao">validacao correspondente a acao que sera executada</param>
        /// <param name="acao">acao que sera aplicada a entidade</param>
        /// <returns>Resultado da validacao</returns>
        public virtual ValidationResult ExecutarQuandoForValido(TEntity entity, Func<ValidationResult> validacao, Action acao)
        {
            // testa a validacao padrao
            ValidationResult result = Validate(entity);
            // caso o estado do objeto seja valido, executa a validacao para a operacao em questao
            if (result.IsValid)
            {
                if (validacao != null)
                    result = validacao();
                // se o resultado for valido, executa a acao desejada
                if (result.IsValid)
                    acao();
            }
            //retorna o resultado da validacao
            return result;

        }
        public virtual ValidationResult ExecutarQuandoForValido(IEnumerable<TEntity> entities, Func<ValidationResult> validacao, Action acao)
        {

            ValidationResult result = new ValidationResult();

            foreach (var item in entities)
            {
                result = Validate(item);
                if (result.IsValid)
                {
                    if (validacao != null)
                    {
                        result = validacao();
                        if (!result.IsValid)
                            break;
                    }
                }
                else break;
            }
            if (result.IsValid)
                acao();
            return result;
        }

        /// <summary>
        /// Testa se as espeficacoes do objeto estão satisfeitas
        /// </summary>
        /// <param name="entity">Entitdade a ser testada</param>
        /// <returns>Resultado da validação com sua(s) mensagem(ns) de erro correspondente, quando houver </returns>
        public virtual ValidationResult Validate(TEntity entity)
        {
            ISelfValidation validator = entity as ISelfValidation;

            return validator.ValidationResult;
        }
        /// <summary>
        /// Testa se o estado do objeto permite que ele seja inserido no sistema
        /// </summary>
        /// <param name="entity">entidade a ser incluida no sistema </param>
        /// <returns>resultado da validacao da entidade </returns>
        public abstract ValidationResult ValidarAdicicao(TEntity entity);
        /// <summary>
        /// Testa se o estado do objeto permite que ele seja atualizado no sistema
        /// </summary>
        /// <param name="entity">entidade a ser atualizada no sistema </param>
        /// <returns>resultado da validacao da entidade </returns>
        public abstract ValidationResult ValidarAtualizacao(TEntity entity);
        /// <summary>
        /// Testa se o estado do objeto permite que ele seja exluido no sistema
        /// </summary>
        /// <param name="entity">entidade a ser excluida no sistema </param>
        /// <returns>resultado da validacao da entidade </returns>
        public abstract ValidationResult ValidarRemocao(TEntity entity);

        public SearchResult<TEntity> BuscaAvancada(Expression<Func<TEntity, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0)
        {
            return this._service.BuscaAvancada(condition, orderBy, sortDirection, take, skip);
        }
    }
}
