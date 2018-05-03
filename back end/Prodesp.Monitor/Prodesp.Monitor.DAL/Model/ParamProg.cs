using System;
using Prodesp.Gsnet.Core.DAL.Interface;
using Prodesp.Gsnet.Core.DAL.Model;

namespace Prodesp.Monitor.DAL.Model
{
    public class ParamProg : BaseModel
    {
        public virtual int IdPrograma { get; set; } 
        public virtual string NmParamProg { get; set; } 
        public virtual string VlParamProg { get; set; } 
        public virtual DateTime? DtInclusao { get; set; } 
        public virtual DateTime? DtAlteracao { get; set; } 
        public virtual string StRegistro { get; set; } 
        public virtual string UserId { get; set; } 
        public virtual ProgramaSaude Programa { get; set; }
    

        public override bool Equals(object obj)
        {
            var other = obj as ParamProg;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
             return IdPrograma == other.IdPrograma && NmParamProg == other.NmParamProg;
        }

        public override int GetHashCode()
        {
            unchecked
            {
              return $"{this.IdPrograma}|{this.NmParamProg}".GetHashCode();
            }
        }

    }
}

