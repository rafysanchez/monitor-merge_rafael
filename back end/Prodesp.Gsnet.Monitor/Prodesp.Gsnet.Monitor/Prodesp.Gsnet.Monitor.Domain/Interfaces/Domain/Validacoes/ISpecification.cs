using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes
{
    public interface ISpecification<in TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}
