using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.Empenho
{
    [Serializable]
    [DataContract(Name = "EmpenhoListResponse", Namespace = "Prodesp.Monitor.TO.Response.Empenho")]
    public class EmpenhoListResponse : ListResponse<EmpenhoListResponseData>
    {
    }
}
