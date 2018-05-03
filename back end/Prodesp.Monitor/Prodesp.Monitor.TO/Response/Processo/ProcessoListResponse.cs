using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.Processo
{
    [Serializable]
    [DataContract(Name = "ProcessoListResponse", Namespace = "Prodesp.Monitor.TO.Response.Processo")]
    public class ProcessoListResponse : ListResponse<ProcessoListResponseData>
    {
    }
}
