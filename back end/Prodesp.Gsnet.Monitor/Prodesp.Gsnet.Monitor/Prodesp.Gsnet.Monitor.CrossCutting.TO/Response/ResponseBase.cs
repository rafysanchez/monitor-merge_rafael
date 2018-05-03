using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.Response
{
    public interface IResponseBase
    {
        bool HasErrors { get; set; }
        string Message { get; set; }
    }
}
