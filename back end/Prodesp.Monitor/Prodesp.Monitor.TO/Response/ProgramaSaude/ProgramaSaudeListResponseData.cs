using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Response.ProgramaSaude
{
    [Serializable]
    [DataContract(Name = "ProgramaSaudeListResponseData", Namespace = "Prodesp.Monitor.TO.Response.ProgramaSaude")]
    public class ProgramaSaudeListResponseData
    {
        [DataMember]
        public int IdPrograma { get; set; }
        [DataMember]
        public string NmPrograma { get; set; }
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
