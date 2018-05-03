using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Repositorios
{
    public interface IRepository<TEntity> : IEntityInteractions<TEntity>
    {
    }
}
