using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.TpAcao
{
    [Serializable]
    [DataContract(Name = "TpAcaoSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.TpAcao")]
    public class TpAcaoSingleRequest : SingleRequest<TpAcaoSingleRequestData>
    {
    }
}
