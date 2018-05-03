using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Request.Empenho
{
    [Serializable]
    [DataContract(Name = "EmpenhoSingleRequestData", Namespace = "Prodesp.Monitor.TO.Request.Empenho")]
    public class EmpenhoSingleRequestData
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
        public string StSituacao { get; set; }
    }
}
