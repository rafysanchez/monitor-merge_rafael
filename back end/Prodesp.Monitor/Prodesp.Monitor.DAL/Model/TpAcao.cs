using System;
using Prodesp.Gsnet.Core.DAL.Interface;
using Prodesp.Gsnet.Core.DAL.Model;

namespace Prodesp.Monitor.DAL.Model
{
    public class TpAcao : BaseModel
    {
        public virtual int IdTpAcao { get; set; } 
        public virtual string DsTpAcao { get; set; } 
        public virtual string StRegistro { get; set; } 
        public virtual DateTime DtInclusao { get; set; } 
        public virtual DateTime DtAlteracao { get; set; } 
        public virtual string UserId { get; set; } 

        public override bool Equals(object obj)
        {
            var other = obj as TpAcao;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
             return IdTpAcao == other.IdTpAcao;
        }

        public override int GetHashCode()
        {
            unchecked
            {
              return $"{this.IdTpAcao}".GetHashCode();
            }
        }

    }
}

