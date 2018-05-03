using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.ProcessoFila
{
    [Serializable]
    [DataContract(Name = "ProcessoFilaSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.ProcessoFila")]
    public class ProcessoFilaSingleRequest : SingleRequest<ProcessoFilaSingleRequestData>
    {
    }
}
