using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.Evento
{
    [Serializable]
    [DataContract(Name = "EventoListResponse", Namespace = "Prodesp.Monitor.TO.Response.Evento")]
    public class EventoListResponse : ListResponse<EventoListResponseData>
    {
    }
}
