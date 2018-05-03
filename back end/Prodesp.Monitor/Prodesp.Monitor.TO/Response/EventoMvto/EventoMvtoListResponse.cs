using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.EventoMvto
{
    [Serializable]
    [DataContract(Name = "EventoMvtoListResponse", Namespace = "Prodesp.Monitor.TO.Response.EventoMvto")]
    public class EventoMvtoListResponse : ListResponse<EventoMvtoListResponseData>
    {
    }
}
