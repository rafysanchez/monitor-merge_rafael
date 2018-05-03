using System;
using Prodesp.Gsnet.Core.DAL.Interface;
using Prodesp.Gsnet.Core.DAL.Model;

namespace Prodesp.Monitor.DAL.Model
{
    public class TpMotivo : BaseModel
    {
        public virtual int IdMotivo { get; set; } 
        public virtual string DsMotivo { get; set; } 
        public virtual string StRegistro { get; set; } 
        public virtual DateTime DtInclusao { get; set; } 
        public virtual DateTime DtAlteracao { get; set; } 
        public virtual string UserId { get; set; } 

        public override bool Equals(object obj)
        {
            var other = obj as TpMotivo;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
             return IdMotivo == other.IdMotivo;
        }

        public override int GetHashCode()
        {
            unchecked
            {
              return $"{this.IdMotivo}".GetHashCode();
            }
        }

    }
}

