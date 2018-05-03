using Ninject.Modules;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.Mapper;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.IoC.Modules
{
    public class CrossCuttingModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IEntityTypeConverter<,>)).To(typeof(GenericEntityTypeConverter<,>));
        }
    }
}
