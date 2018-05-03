using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Request.Processo
{
    [Serializable]
    [DataContract(Name = "ProcessoSingleRequestData", Namespace = "Prodesp.Monitor.TO.Request.Processo")]
    public class ProcessoSingleRequestData
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdGestor { get; set; }
        [DataMember]
        public int IdLocal { get; set; }
        [DataMember]
        public DateTime DtProcessamento { get; set; }
        [DataMember]
        public string CdPrograma { get; set; }
        [DataMember]
        public decimal IdProcesso { get; set; }
        [DataMember]
        public string NmProcesso { get; set; }
        [DataMember]
        public string DsDescricao { get; set; }
        [DataMember]
        public string FlErro { get; set; }
    }
}
