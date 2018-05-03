using System;
using Prodesp.Gsnet.Core.DAL.Interface;
using Prodesp.Gsnet.Core.DAL.Model;

namespace Prodesp.Monitor.DAL.Model
{
    public class Evento : BaseModel
    {
        public virtual int IdEvento { get; set; } 
        public virtual int? IdGestor { get; set; } 
        public virtual int? IdLocal { get; set; } 
        public virtual int IdItem { get; set; } 
        public virtual DateTime DtInclusao { get; set; } 
        public virtual DateTime DtAlteracao { get; set; } 
        public virtual decimal QtSaldoInicial { get; set; } 
        public virtual decimal? NrAutonomiaInicial { get; set; } 
        public virtual decimal QtSaldo { get; set; } 
        public virtual int QtConsumoMes { get; set; } 
        public virtual decimal QtConsumoMedio { get; set; } 
        public virtual decimal? NrAutonomia { get; set; } 
        public virtual string FlEstoqueCritico { get; set; } 
        public virtual string FlEstoqueZerado { get; set; } 
        public virtual DateTime? DtInicioEstoqueCritico { get; set; } 
        public virtual DateTime? DtFimEstoqueCritico { get; set; } 
        public virtual DateTime? DtInicioEstoqueZerado { get; set; } 
        public virtual DateTime? DtFimEstoqueZerado { get; set; } 
        public virtual string FlPublicacao { get; set; } 
        public virtual DateTime? DtPublicacao { get; set; } 
        public virtual decimal? NrAnoRef { get; set; } 
        public virtual decimal? NrMesRef { get; set; } 
        public virtual string UserId { get; set; } 
        public virtual Gestor Gestor  { get; set; }
        public virtual Item Item { get; set; }
    

        public override bool Equals(object obj)
        {
            var other = obj as Evento;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
             return IdEvento == other.IdEvento;
        }

        public override int GetHashCode()
        {
            unchecked
            {
              return $"{this.IdEvento}".GetHashCode();
            }
        }

    }
}

