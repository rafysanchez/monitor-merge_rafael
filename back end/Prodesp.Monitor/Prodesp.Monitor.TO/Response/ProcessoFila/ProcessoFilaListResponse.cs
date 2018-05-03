using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.ProcessoFila
{
    [Serializable]
    [DataContract(Name = "ProcessoFilaListResponse", Namespace = "Prodesp.Monitor.TO.Response.ProcessoFila")]
    public class ProcessoFilaListResponse : ListResponse<ProcessoFilaListResponseData>
    {
    }
}
