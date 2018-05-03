using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Validate(TEntity entity);
    }
}
