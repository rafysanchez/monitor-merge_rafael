using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.Processo
{
    [Serializable]
    [DataContract(Name = "ProcessoSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.Processo")]
    public class ProcessoSingleRequest : SingleRequest<ProcessoSingleRequestData>
    {
    }
}
