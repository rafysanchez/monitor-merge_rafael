using Ninject;
using Prodesp.Gsnet.Monitor.CrossCutting.IoC.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.IoC
{
    public class IoC
    {
        public readonly IKernel Kernel;
        public IoC()
        {
            this.Kernel = this.GetNinjectModules();
        }
        public StandardKernel GetNinjectModules()
        {
            return new StandardKernel(
                new DomainModule(),
                new InfraModule(),
                new CrossCuttingModule(),
                new RepositoryModule(),
                new ApplicationModule());
        }
    }
}
