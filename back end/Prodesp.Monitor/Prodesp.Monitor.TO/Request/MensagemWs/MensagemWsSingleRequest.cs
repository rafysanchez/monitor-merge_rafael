using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.MensagemWs
{
    [Serializable]
    [DataContract(Name = "MensagemWsSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.MensagemWs")]
    public class MensagemWsSingleRequest : SingleRequest<MensagemWsSingleRequestData>
    {
    }
}
