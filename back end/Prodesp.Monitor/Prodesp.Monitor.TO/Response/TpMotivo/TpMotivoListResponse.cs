using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.TpMotivo
{
    [Serializable]
    [DataContract(Name = "TpMotivoListResponse", Namespace = "Prodesp.Monitor.TO.Response.TpMotivo")]
    public class TpMotivoListResponse : ListResponse<TpMotivoListResponseData>
    {
    }
}
