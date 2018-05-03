using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Request.ProgramaSaude
{
    [Serializable]
    [DataContract(Name = "ProgramaSaudeSingleRequestData", Namespace = "Prodesp.Monitor.TO.Request.ProgramaSaude")]
    public class ProgramaSaudeSingleRequestData
    {
        [DataMember]
        public int IdPrograma { get; set; }
        [DataMember]
        public string NmPrograma { get; set; }
        [DataMember]
        public string StRegistro { get; set; }
        [DataMember]
        public string UserId { get; set; }
    }
}
