using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Request.ParamProg
{
    [Serializable]
    [DataContract(Name = "ParamProgSingleRequestData", Namespace = "Prodesp.Monitor.TO.Request.ParamProg")]
    public class ParamProgSingleRequestData
    {
        [DataMember]
        public int IdPrograma { get; set; }
        [DataMember]
        public string NmParamProg { get; set; }
        [DataMember]
        public string VlParamProg { get; set; }
        [DataMember]
        public string StRegistro { get; set; }
        [DataMember]
        public string UserId { get; set; }
    }
}
