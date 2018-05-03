using System;
using Prodesp.Gsnet.Core.DAL.Interface;
using Prodesp.Gsnet.Core.DAL.Model;

namespace Prodesp.Monitor.DAL.Model
{
    public class Processo : BaseModel
    {
        public virtual int Id { get; set; } 
        public virtual int IdGestor { get; set; } 
        public virtual int IdLocal { get; set; } 
        public virtual DateTime DtProcessamento { get; set; } 
        public virtual string CdPrograma { get; set; } 
        public virtual decimal IdProcesso { get; set; } 
        public virtual string NmProcesso { get; set; } 
        public virtual string DsDescricao { get; set; } 
        public virtual DateTime DtInclusao { get; set; } 
        public virtual DateTime DtAlteracao { get; set; } 
        public virtual string FlErro { get; set; } 

        public override bool Equals(object obj)
        {
            var other = obj as Processo;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
             return Id == other.Id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
              return $"{this.Id}".GetHashCode();
            }
        }

    }
}

