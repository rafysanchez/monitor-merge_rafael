using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.Evento
{
    [Serializable]
    [DataContract(Name = "EventoSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.Evento")]
    public class EventoSingleRequest : SingleRequest<EventoSingleRequestData>
    {
    }
}
