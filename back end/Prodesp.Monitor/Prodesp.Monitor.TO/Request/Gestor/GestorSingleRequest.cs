using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.Gestor
{
    [Serializable]
    [DataContract(Name = "GestorSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.Gestor")]
    public class GestorSingleRequest : SingleRequest<GestorSingleRequestData>
    {
    }
}
