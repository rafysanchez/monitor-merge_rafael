using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Validacoes
{
    public class ValidationError
    {
        public string Message { get; set; }
        public ValidationError(string message)
        {
            Message = message;
        }
    }
}
