using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Dispose(bool disposing);
        object GetSession();
        ValidationResult Save();

    }
}
