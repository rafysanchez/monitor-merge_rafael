using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Response.Empenho
{
    [Serializable]
    [DataContract(Name = "EmpenhoListResponseData", Namespace = "Prodesp.Monitor.TO.Response.Empenho")]
    public class EmpenhoListResponseData
    {
        [DataMember]
        public decimal NrEmpenho { get; set; }
        [DataMember]
        public decimal NrAnoEmpenho { get; set; }
        [DataMember]
        public int IdItem { get; set; }
        [DataMember]
        public int IdGestor { get; set; }
        [DataMember]
        public int IdLocal { get; set; }
        [DataMember]
        public decimal? QtUnitEmpenho { get; set; }
        [DataMember]
        public decimal? QtUnitAdiantada { get; set; }
        [DataMember]
        public DateTime? DtInclusao { get; set; }
        [DataMember]
        public DateTime? DtAlteracao { get; set; }
        [DataMember]
        public string StSituacao { get; set; }
    }
}
