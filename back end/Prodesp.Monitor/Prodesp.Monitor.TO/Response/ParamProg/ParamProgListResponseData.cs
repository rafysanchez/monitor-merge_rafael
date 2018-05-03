using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Response.ParamProg
{
    [Serializable]
    [DataContract(Name = "ParamProgListResponseData", Namespace = "Prodesp.Monitor.TO.Response.ParamProg")]
    public class ParamProgListResponseData
    {
        [DataMember]
        public int IdPrograma { get; set; }
        [DataMember]
        public string NmParamProg { get; set; }
        [DataMember]
        public string VlParamProg { get; set; }
        [DataMember]
        public DateTime? DtInclusao { get; set; }
        [DataMember]
        public DateTime? DtAlteracao { get; set; }
        [DataMember]
        public string StRegistro { get; set; }
        [DataMember]
        public string UserId { get; set; }
    }
}
