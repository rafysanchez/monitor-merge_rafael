using System;
using Prodesp.Gsnet.Core.DAL.Interface;
using Prodesp.Gsnet.Core.DAL.Model;

namespace Prodesp.Monitor.DAL.Model
{
    public class Item : BaseModel
    {
        public virtual int IdItem { get; set; } 
        public virtual string NmUnidMedida { get; set; } 
        public virtual string NmItem { get; set; } 
        public virtual string NmItemFonetico { get; set; } 
        public virtual int? IdProgramaSaude { get; set; } 
        public virtual string NmProgramaSaude { get; set; } 
        public virtual string StRegistro { get; set; } 
        public virtual DateTime DtInclusao { get; set; } 
        public virtual DateTime DtAlteracao { get; set; } 
        public virtual string UserId { get; set; } 
        public virtual string CdSiafisico { get; set; } 
        public virtual decimal? QtFatorConversao { get; set; } 

        public override bool Equals(object obj)
        {
            var other = obj as Item;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
             return IdItem == other.IdItem;
        }

        public override int GetHashCode()
        {
            unchecked
            {
              return $"{this.IdItem}".GetHashCode();
            }
        }

    }
}

