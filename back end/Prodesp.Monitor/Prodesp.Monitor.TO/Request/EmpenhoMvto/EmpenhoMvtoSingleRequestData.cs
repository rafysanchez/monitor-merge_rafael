using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Request.EmpenhoMvto
{
    [Serializable]
    [DataContract(Name = "EmpenhoMvtoSingleRequestData", Namespace = "Prodesp.Monitor.TO.Request.EmpenhoMvto")]
    public class EmpenhoMvtoSingleRequestData
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
        public decimal? QtUnitEmpenho { get; set; }
        [DataMember]
        public decimal QtUnitAdiantada { get; set; }
        [DataMember]
        public string StSituacao { get; set; }
    }
}
