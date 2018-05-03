using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.TpAcao
{
    [Serializable]
    [DataContract(Name = "TpAcaoListResponse", Namespace = "Prodesp.Monitor.TO.Response.TpAcao")]
    public class TpAcaoListResponse : ListResponse<TpAcaoListResponseData>
    {
    }
}
