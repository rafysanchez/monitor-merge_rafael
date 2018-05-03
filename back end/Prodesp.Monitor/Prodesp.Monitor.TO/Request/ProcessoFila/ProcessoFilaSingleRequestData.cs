using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Request.ProcessoFila
{
    [Serializable]
    [DataContract(Name = "ProcessoFilaSingleRequestData", Namespace = "Prodesp.Monitor.TO.Request.ProcessoFila")]
    public class ProcessoFilaSingleRequestData
    {
        [DataMember]
        public int IdGestor { get; set; }
        [DataMember]
        public int IdLocal { get; set; }
        [DataMember]
        public string CdAcao { get; set; }
        [DataMember]
        public string UserId { get; set; }
    }
}
