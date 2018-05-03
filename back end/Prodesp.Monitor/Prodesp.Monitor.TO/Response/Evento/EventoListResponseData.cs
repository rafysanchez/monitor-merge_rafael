using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Response.Evento
{
    [Serializable]
    [DataContract(Name = "EventoListResponseData", Namespace = "Prodesp.Monitor.TO.Response.Evento")]
    public class EventoListResponseData
    {
        [DataMember]
        public int IdEvento { get; set; }
        [DataMember]
        public int? IdGestor { get; set; }
        [DataMember]
        public int? IdLocal { get; set; }
        [DataMember]
        public int IdItem { get; set; }
        [DataMember]
        public DateTime DtInclusao { get; set; }
        [DataMember]
        public DateTime DtAlteracao { get; set; }
        [DataMember]
        public decimal QtSaldoInicial { get; set; }
        [DataMember]
        public decimal? NrAutonomiaInicial { get; set; }
        [DataMember]
        public decimal QtSaldo { get; set; }
        [DataMember]
        public int QtConsumoMes { get; set; }
        [DataMember]
        public decimal QtConsumoMedio { get; set; }
        [DataMember]
        public decimal? NrAutonomia { get; set; }
        [DataMember]
        public string FlEstoqueCritico { get; set; }
        [DataMember]
        public string FlEstoqueZerado { get; set; }
        [DataMember]
        public DateTime? DtInicioEstoqueCritico { get; set; }
        [DataMember]
        public DateTime? DtFimEstoqueCritico { get; set; }
        [DataMember]
        public DateTime? DtInicioEstoqueZerado { get; set; }
        [DataMember]
        public DateTime? DtFimEstoqueZerado { get; set; }
        [DataMember]
        public string FlPublicacao { get; set; }
        [DataMember]
        public DateTime? DtPublicacao { get; set; }
        [DataMember]
        public decimal? NrAnoRef { get; set; }
        [DataMember]
        public decimal? NrMesRef { get; set; }
        [DataMember]
        public string UserId { get; set; }
    }
}
