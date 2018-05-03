using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Response.Parametros
{
    [Serializable]
    [DataContract(Name = "ParametrosListResponseData", Namespace = "Prodesp.Monitor.TO.Response.Parametros")]
    public class ParametrosListResponseData
    {
        [DataMember]
        public string NmParam { get; set; }
        [DataMember]
        public string DsParam { get; set; }
        [DataMember]
        public string VlParam { get; set; }
    }
}
