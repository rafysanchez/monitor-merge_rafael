using System.Linq;
using FluentValidation.Results;
using Prodesp.Monitor.DAL.Model;
using Prodesp.Monitor.BLL.Validation;
using Prodesp.Core.NHibernate.BLL;

namespace Prodesp.Monitor.BLL.Bll
{
    public class TpMotivoBllNHibernate : CustomGsnetNHibernateBLL<TpMotivo>
    {

        #region .: Cto :.

        public TpMotivoBllNHibernate(): base()
        {
        }

        #endregion

        #region .: Regras de validação :. 

        protected override ValidationResult ValidateCreate(TpMotivo obj)
        {
            var validator = new TpMotivoValidation(BaseValidationBllNHibernate<TpMotivo>.EventoValidacao.Create);
            return validator.Validate(obj);
        }

        protected override ValidationResult ValidateUpdate(TpMotivo obj)
        {
            var validator = new TpMotivoValidation(BaseValidationBllNHibernate<TpMotivo>.EventoValidacao.Edit);
            return validator.Validate(obj);
        }

        protected override ValidationResult ValidateDelete(TpMotivo obj)
        {
            var validator = new TpMotivoValidation(BaseValidationBllNHibernate<TpMotivo>.EventoValidacao.Delete);
            return validator.Validate(obj);
        }

        #endregion 

        #region .: CRUD :.

        protected override TpMotivo InternalGetById(TpMotivo model)
        {
            return PersistenceContext.Query<TpMotivo>().FirstOrDefault(f => f.IdMotivo == model.IdMotivo );
        }

        public TpMotivo GetById(int IdMotivo)
        {
            return PersistenceContext.Query<TpMotivo>().FirstOrDefault(f => f.IdMotivo == IdMotivo );
        }
        #endregion 

        #region .: Extension Methods :. 


        #endregion 
    }
}
