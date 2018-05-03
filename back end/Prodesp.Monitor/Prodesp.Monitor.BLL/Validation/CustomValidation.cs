using Prodesp.Core.NHibernate.BLL;
using System;
using System.Linq;

namespace Prodesp.Monitor.BLL.Validation
{
    public abstract class CustomValidation<T> : BaseValidationBllNHibernate<T>
    {
        public CustomValidation(EventoValidacao e) : base(e)
        {

        }

        protected virtual bool ValidateGuid(string idGuid)
        {
            Guid guid;
            return Guid.TryParse(idGuid,out guid);
        }

        protected virtual bool ValidateStatusRegistro(string value)
        {
            if (string.IsNullOrEmpty(value) == true)
            {
                return false;
            }
            if (new string[] { "S", "C", "I", "R", "D", "E" }.Contains(value) == false)
            {
                return false;
            }
            return true;
        }

        //protected virtual bool IsGestor(int? idGestor)
        //{
        //    if (idGestor.HasValue == false)
        //    {
        //        return false;
        //    }
        //    return new GestorBllNHibernate().GetById(idGestor.Value) != null;
        //}

        //protected virtual bool IsGestor(int idGestor)
        //{
        //    return IsGestor((int?)idGestor);
        //}

        protected virtual bool IsFlCancelado(string flCancelado)
        {
            return new string[] { "S", "N" }.Contains((flCancelado ?? "L"));
        }

    }
}
