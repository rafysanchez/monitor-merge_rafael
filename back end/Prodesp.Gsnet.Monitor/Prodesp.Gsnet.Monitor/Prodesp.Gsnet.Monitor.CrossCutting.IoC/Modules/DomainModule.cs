using Ninject.Modules;
using Prodesp.Gsnet.Monitor.Domain.Implementacoes.Domain.Servicos;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.IoC.Modules
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IService<>)).To(typeof(ServiceBase<,>));            
            Bind<IMotivoAcaoService>().To<MotivoAcaoService>();
            Bind<IItemMonitoramentoService>().To<ItemMonitoramentoService>();
            Bind<IMonitoramentoService>().To<MonitoramentoService>();
            Bind<IIndicadoresMonitoramentoService>().To<IndicadoresMonitoramentoService>();
            Bind<IJustificativaService>().To<JustificativaService>();
            Bind<IParametroService>().To<ParametroService>();
            Bind<IRegraMotorService>().To<RegraMotorService>();
            Bind<IProgramaSaudeService>().To<ProgramaSaudeService>();
            Bind<IParametroValorService>().To<ParametroValorService>();
            Bind<IItemService>().To<ItemService>();

        }
    }
}
