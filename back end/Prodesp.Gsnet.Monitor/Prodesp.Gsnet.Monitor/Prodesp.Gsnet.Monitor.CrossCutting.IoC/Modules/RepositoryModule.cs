using Ninject.Modules;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios;
using Prodesp.Gsnet.Monitor.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.IoC.Modules
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {            
            Bind<IMotivoAcaoRepository>().To<MotivoAcaoRepository>();
            Bind<IItemMonitoramentoRepository>().To<ItemMonitoramentoRepository>();
            Bind<IMonitoramentoRepository>().To<MonitoramentoRepository>();
            Bind<IIndicadoresMonitoramentoRepository>().To<IndicadoresMonitoramentoRepository>();
            Bind<IJustificativaRepository>().To<JustificativaRepository>();
            Bind<IParametroRepository>().To<ParametroRepository>();
            Bind<IRegraMotorRepository>().To<RegraMotorRepository>();
            Bind<IProgramaSaudeRepository>().To<ProgramaSaudeRepository>();
            Bind<IParametroValorRepository>().To<ParametroValorRepository>();
            Bind<IItemRepository>().To<ItemRepository>();


        }
    }
}
