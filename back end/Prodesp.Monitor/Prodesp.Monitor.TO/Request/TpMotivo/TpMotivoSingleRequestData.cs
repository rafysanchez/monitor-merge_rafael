using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Prodesp.Monitor.TO.Request.TpMotivo
{
    [Serializable]
    [DataContract(Name = "TpMotivoSingleRequestData", Namespace = "Prodesp.Monitor.TO.Request.TpMotivo")]
    public class TpMotivoSingleRequestData
    {
        [DataMember]
        public int IdMotivo { get; set; }
        [DataMember]
        public string DsMotivo { get; set; }
        [DataMember]
        public string StRegistro { get; set; }
        [DataMember]
        public string UserId { get; set; }
    }
}
