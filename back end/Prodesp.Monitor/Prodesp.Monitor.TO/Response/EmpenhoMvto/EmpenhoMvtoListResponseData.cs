using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Response.EmpenhoMvto
{
    [Serializable]
    [DataContract(Name = "EmpenhoMvtoListResponseData", Namespace = "Prodesp.Monitor.TO.Response.EmpenhoMvto")]
    public class EmpenhoMvtoListResponseData
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
        public int IdMvto { get; set; }
        [DataMember]
        public DateTime DtInclusao { get; set; }
        [DataMember]
        public DateTime DtAlteracao { get; set; }
        [DataMember]
        public decimal? QtUnitEmpenho { get; set; }
        [DataMember]
        public decimal QtUnitAdiantada { get; set; }
        [DataMember]
        public string StSituacao { get; set; }
    }
}
