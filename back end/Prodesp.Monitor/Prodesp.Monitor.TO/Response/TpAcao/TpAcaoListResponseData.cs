using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Response.TpAcao
{
    [Serializable]
    [DataContract(Name = "TpAcaoListResponseData", Namespace = "Prodesp.Monitor.TO.Response.TpAcao")]
    public class TpAcaoListResponseData
    {
        [DataMember]
        public int IdTpAcao { get; set; }
        [DataMember]
        public string DsTpAcao { get; set; }
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
