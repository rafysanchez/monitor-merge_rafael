using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Prodesp.Gsnet.Monitor.CrossCutting.IoC;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data;
using Prodesp.Gsnet.Monitor.Infra.Data.EF.Implementacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Prodesp.Gsnet.Monitor.Presentation.WebApi.App_Start.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Prodesp.Gsnet.Monitor.Presentation.WebApi.App_Start.NinjectConfig), "Stop")]
namespace Prodesp.Gsnet.Monitor.Presentation.WebApi.App_Start
{
    public class NinjectConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            //inject modules
            var ioc = new IoC();

            var kernel = ioc.Kernel;
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                // unit of work per request
                kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>().InRequestScope();

                // default binding for everything except unit of work
                //kernel.Bind(x => x.FromAssembliesMatching("*").SelectAllClasses().Excluding<EFUnitOfWork>().BindDefaultInterface());
                // RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
    }
}