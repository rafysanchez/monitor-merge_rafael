using System;
using Prodesp.Gsnet.Core.DAL.Interface;
using Prodesp.Gsnet.Core.DAL.Model;

namespace Prodesp.Monitor.DAL.Model
{
    public class EventoMvto : BaseModel
    {
        public virtual int IdEvento { get; set; } 
        public virtual int IdMvto { get; set; } 
        public virtual DateTime DtInclusao { get; set; } 
        public virtual DateTime DtAlteracao { get; set; } 
        public virtual decimal QtSaldo { get; set; } 
        public virtual decimal? NrAutonomiaCritica { get; set; } 
        public virtual decimal? NrAutonomia { get; set; } 
        public virtual string FlEstoqueCritico { get; set; } 
        public virtual string FlEstoqueZerado { get; set; } 
        public virtual decimal QtConsumoMes { get; set; } 
        public virtual decimal QtConsumoMedio { get; set; } 
        public virtual DateTime? DtUltSaida { get; set; } 
        public virtual decimal? QtUltSaida { get; set; } 
        public virtual DateTime? DtUltEntrada { get; set; } 
        public virtual decimal? QtUltEntrada { get; set; } 
        public virtual decimal? NrDocumentoUltEntrada { get; set; } 
        public virtual string SrDocumentoUltEntrada { get; set; } 
        public virtual decimal? NrDocumentoUltSaida { get; set; } 
        public virtual string SrDocumentoUltSaida { get; set; } 
        public virtual DateTime? DtUltSaidaFatura { get; set; } 
        public virtual decimal? QtUltSaidaFatura { get; set; } 
        public virtual decimal? NrDocumentoUltSaidaFatura { get; set; } 
        public virtual string SrDocumentoUltSaidaFatura { get; set; } 
        public virtual Evento Evento { get; set; }
    

        public override bool Equals(object obj)
        {
            var other = obj as EventoMvto;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
             return IdEvento == other.IdEvento && IdMvto == other.IdMvto;
        }

        public override int GetHashCode()
        {
            unchecked
            {
              return $"{this.IdEvento}|{this.IdMvto}".GetHashCode();
            }
        }

    }
}

