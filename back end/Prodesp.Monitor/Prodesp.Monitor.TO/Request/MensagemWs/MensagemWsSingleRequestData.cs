using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Request.MensagemWs
{
    [Serializable]
    [DataContract(Name = "MensagemWsSingleRequestData", Namespace = "Prodesp.Monitor.TO.Request.MensagemWs")]
    public class MensagemWsSingleRequestData
    {
        [DataMember]
        public int IdMensagem { get; set; }
        [DataMember]
        public string DsMensagem { get; set; }
        [DataMember]
        public string StRegistro { get; set; }
    }
}
