using System;
using Prodesp.Gsnet.Core.DAL.Interface;
using Prodesp.Gsnet.Core.DAL.Model;

namespace Prodesp.Monitor.DAL.Model
{
    public class EmpenhoMvto : BaseModel
    {
        public virtual decimal NrEmpenho { get; set; } 
        public virtual decimal NrAnoEmpenho { get; set; } 
        public virtual int IdItem { get; set; } 
        public virtual int IdGestor { get; set; } 
        public virtual int IdLocal { get; set; } 
        public virtual int IdMvto { get; set; } 
        public virtual DateTime DtInclusao { get; set; } 
        public virtual DateTime DtAlteracao { get; set; } 
        public virtual decimal? QtUnitEmpenho { get; set; } 
        public virtual decimal QtUnitAdiantada { get; set; } 
        public virtual string StSituacao { get; set; } 
        public virtual Empenho Empenho  { get; set; }
    

        public override bool Equals(object obj)
        {
            var other = obj as EmpenhoMvto;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
             return NrEmpenho == other.NrEmpenho && NrAnoEmpenho == other.NrAnoEmpenho && IdItem == other.IdItem && IdGestor == other.IdGestor && IdLocal == other.IdLocal && IdMvto == other.IdMvto;
        }

        public override int GetHashCode()
        {
            unchecked
            {
              return $"{this.NrEmpenho}|{this.NrAnoEmpenho}|{this.IdItem}|{this.IdGestor}|{this.IdLocal}|{this.IdMvto}".GetHashCode();
            }
        }

    }
}

