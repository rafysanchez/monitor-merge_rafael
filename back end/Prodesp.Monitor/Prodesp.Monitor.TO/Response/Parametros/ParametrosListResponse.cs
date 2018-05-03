using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.Parametros
{
    [Serializable]
    [DataContract(Name = "ParametrosListResponse", Namespace = "Prodesp.Monitor.TO.Response.Parametros")]
    public class ParametrosListResponse : ListResponse<ParametrosListResponseData>
    {
    }
}
