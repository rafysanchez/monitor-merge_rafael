using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.Empenho
{
    [Serializable]
    [DataContract(Name = "EmpenhoSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.Empenho")]
    public class EmpenhoSingleRequest : SingleRequest<EmpenhoSingleRequestData>
    {
    }
}
