using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Request.Parametros
{
    [Serializable]
    [DataContract(Name = "ParametrosSingleRequestData", Namespace = "Prodesp.Monitor.TO.Request.Parametros")]
    public class ParametrosSingleRequestData
    {
        [DataMember]
        public string NmParam { get; set; }
        [DataMember]
        public string DsParam { get; set; }
        [DataMember]
        public string VlParam { get; set; }
    }
}
