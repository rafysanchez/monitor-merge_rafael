using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Response.MensagemWs
{
    [Serializable]
    [DataContract(Name = "MensagemWsListResponseData", Namespace = "Prodesp.Monitor.TO.Response.MensagemWs")]
    public class MensagemWsListResponseData
    {
        [DataMember]
        public int IdMensagem { get; set; }
        [DataMember]
        public string DsMensagem { get; set; }
        [DataMember]
        public string StRegistro { get; set; }
        [DataMember]
        public DateTime DtInclusao { get; set; }
        [DataMember]
        public DateTime DtAlteracao { get; set; }
    }
}
