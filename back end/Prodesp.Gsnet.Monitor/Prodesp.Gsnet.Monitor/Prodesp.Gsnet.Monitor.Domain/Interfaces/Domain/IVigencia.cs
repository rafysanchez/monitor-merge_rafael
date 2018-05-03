using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain
{
    public interface IVigencia
    {
         DateTime DataInicioVigencia { get; set; }
         DateTime? DataFimVigencia { get; set; }
         string FlagAtivo { get; set; }
    }
}
