using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Response.Processo
{
    [Serializable]
    [DataContract(Name = "ProcessoListResponseData", Namespace = "Prodesp.Monitor.TO.Response.Processo")]
    public class ProcessoListResponseData
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
        public DateTime DtInclusao { get; set; }
        [DataMember]
        public DateTime DtAlteracao { get; set; }
        [DataMember]
        public string FlErro { get; set; }
    }
}
