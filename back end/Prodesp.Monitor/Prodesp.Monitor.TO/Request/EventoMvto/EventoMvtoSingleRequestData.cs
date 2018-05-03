using System;
using System.Runtime.Serialization;

namespace Prodesp.Monitor.TO.Request.EventoMvto
{
    [Serializable]
    [DataContract(Name = "EventoMvtoSingleRequestData", Namespace = "Prodesp.Monitor.TO.Request.EventoMvto")]
    public class EventoMvtoSingleRequestData
    {
        [DataMember]
        public int IdEvento { get; set; }
        [DataMember]
        public int IdMvto { get; set; }
        [DataMember]
        public decimal QtSaldo { get; set; }
        [DataMember]
        public decimal? NrAutonomiaCritica { get; set; }
        [DataMember]
        public decimal? NrAutonomia { get; set; }
        [DataMember]
        public string FlEstoqueCritico { get; set; }
        [DataMember]
        public string FlEstoqueZerado { get; set; }
        [DataMember]
        public decimal QtConsumoMes { get; set; }
        [DataMember]
        public decimal QtConsumoMedio { get; set; }
        [DataMember]
        public DateTime? DtUltSaida { get; set; }
        [DataMember]
        public decimal? QtUltSaida { get; set; }
        [DataMember]
        public DateTime? DtUltEntrada { get; set; }
        [DataMember]
        public decimal? QtUltEntrada { get; set; }
        [DataMember]
        public decimal? NrDocumentoUltEntrada { get; set; }
        [DataMember]
        public string SrDocumentoUltEntrada { get; set; }
        [DataMember]
        public decimal? NrDocumentoUltSaida { get; set; }
        [DataMember]
        public string SrDocumentoUltSaida { get; set; }
        [DataMember]
        public DateTime? DtUltSaidaFatura { get; set; }
        [DataMember]
        public decimal? QtUltSaidaFatura { get; set; }
        [DataMember]
        public decimal? NrDocumentoUltSaidaFatura { get; set; }
        [DataMember]
        public string SrDocumentoUltSaidaFatura { get; set; }
    }
}
