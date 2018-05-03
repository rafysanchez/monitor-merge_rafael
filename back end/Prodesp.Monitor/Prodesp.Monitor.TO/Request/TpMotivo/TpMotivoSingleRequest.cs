using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.TpMotivo
{
    [Serializable]
    [DataContract(Name = "TpMotivoSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.TpMotivo")]
    public class TpMotivoSingleRequest : SingleRequest<TpMotivoSingleRequestData>
    {
    }
}
