using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Response.Gestor
{
    [Serializable]
    [DataContract(Name = "GestorListResponseData", Namespace = "Prodesp.Monitor.TO.Response.Gestor")]
    public class GestorListResponseData
    {
        [DataMember]
        public DateTime DtInclusao { get; set; }
        [DataMember]
        public int IdGestor { get; set; }
        [DataMember]
        public int IdLocal { get; set; }
        [DataMember]
        public int IdInstitucional { get; set; }
        [DataMember]
        public int? IdGestorPai { get; set; }
        [DataMember]
        public int? IdLocalPai { get; set; }
        [DataMember]
        public decimal? NrAnoRef { get; set; }
        [DataMember]
        public decimal? NrMesRef { get; set; }
        [DataMember]
        public string NmInstitucional { get; set; }
        [DataMember]
        public int? IdInstitucionalPai { get; set; }
        [DataMember]
        public string StRegistro { get; set; }
        [DataMember]
        public DateTime DtAlteracao { get; set; }
        [DataMember]
        public string NmLocal { get; set; }
        [DataMember]
        public DateTime? DtProcessamento { get; set; }
    }
}
