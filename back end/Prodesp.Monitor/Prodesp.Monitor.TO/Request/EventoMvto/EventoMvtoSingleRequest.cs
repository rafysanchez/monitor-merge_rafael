using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.EventoMvto
{
    [Serializable]
    [DataContract(Name = "EventoMvtoSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.EventoMvto")]
    public class EventoMvtoSingleRequest : SingleRequest<EventoMvtoSingleRequestData>
    {
    }
}
