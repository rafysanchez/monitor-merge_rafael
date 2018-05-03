using System;
using Prodesp.Gsnet.Core.DAL.Interface;
using Prodesp.Gsnet.Core.DAL.Model;

namespace Prodesp.Monitor.DAL.Model
{
    public class ProcessoFila : BaseModel
    {
        public virtual int IdGestor { get; set; } 
        public virtual int IdLocal { get; set; } 
        public virtual string CdAcao { get; set; } 
        public virtual string UserId { get; set; } 

        public override bool Equals(object obj)
        {
            var other = obj as ProcessoFila;
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

