using Prodesp.Gsnet.Monitor.Domain.Interfaces.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.Mapper
{
    public class GenericEntityTypeConverter<TDomainEntity,TViewModelEntity> : IEntityTypeConverter<TDomainEntity, TViewModelEntity>
    {
        public TViewModelEntity ToViewModel(TDomainEntity entity)
        {
            return AutoMapper.Mapper.Map<TViewModelEntity>(entity);
        }
        public IEnumerable<TViewModelEntity> ToViewModel(IEnumerable<TDomainEntity> entity)
        {
            return entity.Select(x => this.ToViewModel(x));
        }
        public TDomainEntity ToDomainEntity(TViewModelEntity viewModel)
        {
            return AutoMapper.Mapper.Map<TDomainEntity>(viewModel);
        }
        public IEnumerable<TDomainEntity> ToViewModel(IEnumerable<TViewModelEntity> entity)
        {
            return entity.Select(x => this.ToDomainEntity(x));
        }
    }
}
