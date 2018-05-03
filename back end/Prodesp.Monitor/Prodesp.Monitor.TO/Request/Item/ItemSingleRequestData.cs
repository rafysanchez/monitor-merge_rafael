using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Request.Item
{
    [Serializable]
    [DataContract(Name = "ItemSingleRequestData", Namespace = "Prodesp.Monitor.TO.Request.Item")]
    public class ItemSingleRequestData
    {
        [DataMember]
        public int IdItem { get; set; }
        [DataMember]
        public string NmUnidMedida { get; set; }
        [DataMember]
        public string NmItem { get; set; }
        [DataMember]
        public string NmItemFonetico { get; set; }
        [DataMember]
        public int? IdProgramaSaude { get; set; }
        [DataMember]
        public string NmProgramaSaude { get; set; }
        [DataMember]
        public string StRegistro { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string CdSiafisico { get; set; }
        [DataMember]
        public decimal? QtFatorConversao { get; set; }
    }
}
