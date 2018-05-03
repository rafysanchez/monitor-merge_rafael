using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.EmpenhoMvto
{
    [Serializable]
    [DataContract(Name = "EmpenhoMvtoListResponse", Namespace = "Prodesp.Monitor.TO.Response.EmpenhoMvto")]
    public class EmpenhoMvtoListResponse : ListResponse<EmpenhoMvtoListResponseData>
    {
    }
}
