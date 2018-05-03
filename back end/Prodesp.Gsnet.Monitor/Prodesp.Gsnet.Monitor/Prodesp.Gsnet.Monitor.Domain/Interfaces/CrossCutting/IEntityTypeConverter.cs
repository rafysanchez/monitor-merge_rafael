using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.CrossCutting
{
    public interface IEntityTypeConverter<TDomainEntity, TViewModelEntity>
    {
        /// <summary>
        /// Converte uma entidade de dominio para uma entidade de view model(DTO e etc )
        /// </summary>
        /// <param name="entity">Entidade de dominio a ser convertida</param>
        /// <returns>entidade em formato no formato do view model correspondente</returns>
        TViewModelEntity ToViewModel(TDomainEntity entity);
        /// <summary>
        /// Converte uma colecao de entidades de dominio para uma colecao entidades de view model(DTO e etc )
        /// </summary>
        /// <param name="entity">colecao de entidade de dominio</param>
        /// <returns></returns>
        IEnumerable<TViewModelEntity> ToViewModel(IEnumerable<TDomainEntity> entity);
        /// <summary>
        /// Converte uma entidade de dominio para uma entidade de view model(DTO e etc )
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        TDomainEntity ToDomainEntity(TViewModelEntity viewModel);
        IEnumerable<TDomainEntity> ToViewModel(IEnumerable<TViewModelEntity> entity);
    }
}
