using System;
using Prodesp.Gsnet.Core.DAL.Interface;
using Prodesp.Gsnet.Core.DAL.Model;

namespace Prodesp.Monitor.DAL.Model
{
    public class Gestor : BaseModel
    {
        public virtual DateTime DtInclusao { get; set; } 
        public virtual int IdGestor { get; set; } 
        public virtual int IdLocal { get; set; } 
        public virtual int IdInstitucional { get; set; } 
        public virtual int? IdGestorPai { get; set; } 
        public virtual int? IdLocalPai { get; set; } 
        public virtual decimal? NrAnoRef { get; set; } 
        public virtual decimal? NrMesRef { get; set; } 
        public virtual string NmInstitucional { get; set; } 
        public virtual int? IdInstitucionalPai { get; set; } 
        public virtual string StRegistro { get; set; } 
        public virtual DateTime DtAlteracao { get; set; } 
        public virtual string NmLocal { get; set; } 
        public virtual DateTime? DtProcessamento { get; set; } 
        public virtual Gestor GestorPai  { get; set; }
    

        public override bool Equals(object obj)
        {
            var other = obj as Gestor;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
             return IdGestor == other.IdGestor && IdLocal == other.IdLocal;
        }

        public override int GetHashCode()
        {
            unchecked
            {
              return $"{this.IdGestor}|{this.IdLocal}".GetHashCode();
            }
        }

    }
}

