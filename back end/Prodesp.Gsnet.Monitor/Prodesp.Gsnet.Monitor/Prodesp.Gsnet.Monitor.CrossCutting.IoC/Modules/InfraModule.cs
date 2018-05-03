using Ninject.Modules;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios;
using Prodesp.Gsnet.Monitor.Infra.Data.EF.Implementacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.IoC.Modules
{
    public class InfraModule : NinjectModule
    {
        public override void Load()
        {
           // Bind(typeof(ARepository<>)).To(typeof(EFRepositorioBase<>)).InSingletonScope();
            //Bind<IUnitOfWork>().To<EFUnitOfWork>().in();
        }
    }
}
