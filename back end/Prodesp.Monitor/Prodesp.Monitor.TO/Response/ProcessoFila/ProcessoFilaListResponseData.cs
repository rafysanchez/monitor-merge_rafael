using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Response.ProcessoFila
{
    [Serializable]
    [DataContract(Name = "ProcessoFilaListResponseData", Namespace = "Prodesp.Monitor.TO.Response.ProcessoFila")]
    public class ProcessoFilaListResponseData
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
