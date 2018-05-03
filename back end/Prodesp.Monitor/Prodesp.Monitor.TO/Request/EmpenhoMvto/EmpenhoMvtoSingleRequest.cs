using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.EmpenhoMvto
{
    [Serializable]
    [DataContract(Name = "EmpenhoMvtoSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.EmpenhoMvto")]
    public class EmpenhoMvtoSingleRequest : SingleRequest<EmpenhoMvtoSingleRequestData>
    {
    }
}
