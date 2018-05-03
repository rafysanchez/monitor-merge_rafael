using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.MensagemWs
{
    [Serializable]
    [DataContract(Name = "MensagemWsListResponse", Namespace = "Prodesp.Monitor.TO.Response.MensagemWs")]
    public class MensagemWsListResponse : ListResponse<MensagemWsListResponseData>
    {
    }
}
