using System;
using Prodesp.Gsnet.Core.DAL.Interface;
using Prodesp.Gsnet.Core.DAL.Model;

namespace Prodesp.Monitor.DAL.Model
{
    public class Parametros : BaseModel
    {
        public virtual string NmParam { get; set; } 
        public virtual string DsParam { get; set; } 
        public virtual string VlParam { get; set; } 

        public override bool Equals(object obj)
        {
            var other = obj as Parametros;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
             return NmParam == other.NmParam;
        }

        public override int GetHashCode()
        {
            unchecked
            {
              return $"{this.NmParam}".GetHashCode();
            }
        }

    }
}

