using Ninject.Modules;
using Prodesp.Gsnet.Monitor.Application.Implementacoes;
using Prodesp.Gsnet.Monitor.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.IoC.Modules
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IAppService<>)).To(typeof(AppService<,>));           
            Bind<IMotivoAcaoAppService>().To<MotivoAcaoAppService>();
            Bind<IItemMonitoramentoAppService>().To<ItemMonitoramentoAppService>();
            Bind<IMonitoramentoAppService>().To<MonitoramentoAppService>();
            Bind<IJusticativaAppService>().To<JustificativaAppService>();
            Bind<IParametroAppService>().To<ParametroAppService>();
            Bind<IRegraMotorAppService>().To<RegraMotorAppService>();
            Bind<IProgramaSaudeAppService>().To<ProgramaSaudeAppService>();
            Bind<IParametroValorAppService>().To<ParametroValorAppService>();
            Bind<IItemAppService>().To<ItemAppService>();
        }
    }
}
