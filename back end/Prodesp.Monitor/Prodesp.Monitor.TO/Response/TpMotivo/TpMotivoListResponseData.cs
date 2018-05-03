using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Response.TpMotivo
{
    [Serializable]
    [DataContract(Name = "TpMotivoListResponseData", Namespace = "Prodesp.Monitor.TO.Response.TpMotivo")]
    public class TpMotivoListResponseData
    {
        [DataMember]
        public int IdMotivo { get; set; }
        [DataMember]
        public string DsMotivo { get; set; }
        [DataMember]
        public string StRegistro { get; set; }
        [DataMember]
        public DateTime DtInclusao { get; set; }
        [DataMember]
        public DateTime DtAlteracao { get; set; }
        [DataMember]
        public string UserId { get; set; }
    }
}
