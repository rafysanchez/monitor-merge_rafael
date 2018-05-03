using Prodesp.Gsnet.Monitor.Domain;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Application.Interfaces
{
    public interface IMotivoAcaoAppService : IAppService<MotivoAcao>
    {
        IEnumerable<MotivoAcao> BuscarPorTipo(MotivoAcaoEnum tipo);
    }
}
