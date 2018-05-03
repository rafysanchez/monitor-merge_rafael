using Prodesp.Gsnet.Core.TO.Response;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.Response
{
    public class MonitoramentoResponse : SingleResponse<MonitoramentoViewModel>, IResponseBase
    {
        public bool HasErrors
        {
            get;

            set;
        }
    }
    public class IndicadoresResponse : SingleResponse<IndicadoresViewModel>, IResponseBase
    {
        public bool HasErrors
        {
            get;

            set;
        }
    }
}
