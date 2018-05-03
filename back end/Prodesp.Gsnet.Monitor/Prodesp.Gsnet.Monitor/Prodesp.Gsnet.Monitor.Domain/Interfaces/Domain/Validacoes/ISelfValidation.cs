using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
