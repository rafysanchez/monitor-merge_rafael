using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Request.TpAcao
{
    [Serializable]
    [DataContract(Name = "TpAcaoSingleRequestData", Namespace = "Prodesp.Monitor.TO.Request.TpAcao")]
    public class TpAcaoSingleRequestData
    {
        [DataMember]
        public int IdTpAcao { get; set; }
        [DataMember]
        public string DsTpAcao { get; set; }
        [DataMember]
        public string StRegistro { get; set; }
        [DataMember]
        public string UserId { get; set; }
    }
}
