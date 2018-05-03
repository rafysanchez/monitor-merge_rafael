using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.Gestor
{
    [Serializable]
    [DataContract(Name = "GestorListResponse", Namespace = "Prodesp.Monitor.TO.Response.Gestor")]
    public class GestorListResponse : ListResponse<GestorListResponseData>
    {
    }
}
