using System;
using Prodesp.Gsnet.Core.DAL.Interface;
using Prodesp.Gsnet.Core.DAL.Model;

namespace Prodesp.Monitor.DAL.Model
{
    public class MensagemWs : BaseModel
    {
        public virtual int IdMensagem { get; set; } 
        public virtual string DsMensagem { get; set; } 
        public virtual string StRegistro { get; set; } 
        public virtual DateTime DtInclusao { get; set; } 
        public virtual DateTime DtAlteracao { get; set; } 

        public override bool Equals(object obj)
        {
            var other = obj as MensagemWs;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
             return IdMensagem == other.IdMensagem;
        }

        public override int GetHashCode()
        {
            unchecked
            {
              return $"{this.IdMensagem}".GetHashCode();
            }
        }

    }
}

