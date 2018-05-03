using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Response.Item
{
    [Serializable]
    [DataContract(Name = "ItemListResponseData", Namespace = "Prodesp.Monitor.TO.Response.Item")]
    public class ItemListResponseData
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
        public DateTime DtInclusao { get; set; }
        [DataMember]
        public DateTime DtAlteracao { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string CdSiafisico { get; set; }
        [DataMember]
        public decimal? QtFatorConversao { get; set; }
    }
}
