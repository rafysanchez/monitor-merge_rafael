using Prodesp.Core.NHibernate.BLL;
using Prodesp.Gsnet.Core.TO.Enums;
using Prodesp.Gsnet.Core.TO.Validation;
using Prodesp.Monitor.DAL.DataBase.Schema;
using Prodesp.Monitor.Framework.Extension.Helper;
using System.Linq;

namespace Prodesp.Monitor.BLL.Bll
{
    public abstract class CustomGsnetNHibernateBLL<TModel> : BaseNHibernateBLL<TModel, GsnetBootstrapper>  where TModel : class
    {
        public CustomGsnetNHibernateBLL() : base(HelperConstantsExtension.ConnectionStringGSNet)
        {

        }

        protected virtual void ValidatePersistenceContextException(Prodesp.Core.NHibernate.DAL.Database.Util.PersistenceContextException ex)
        {
            if (ex.Message.ToLower().Contains("not-null property references"))
            {
                var parts = ex.Message.Split(' ');
                if (parts.Length > 0)
                {
                    var fields = parts.LastOrDefault().Split('.');
                    if (fields.Length > 0)
                    {
                        var property = fields.LastOrDefault();
                        throw new ValidationException(new ValidationData(ServiceResult.ValidationError.GetHashCode(), $"A propriedade {property} possui um valor inválido!"));
                    }
                }
            }
            throw new ValidationException(new ValidationData(ServiceResult.ValidationError.GetHashCode(), "A propriedade possui um valor inválido!"));
        }

        protected override void InternalCreate(TModel obj)
        {
            try
            {
                base.InternalCreate(obj);
            }
            catch (Prodesp.Core.NHibernate.DAL.Database.Util.PersistenceContextException ex)
            {
                ValidatePersistenceContextException(ex);
            }
        }

        protected override void InternalCreateOrUpdate(TModel obj)
        {
            try
            {
                base.InternalCreateOrUpdate(obj);
            }
            catch (Prodesp.Core.NHibernate.DAL.Database.Util.PersistenceContextException ex)
            {
                ValidatePersistenceContextException(ex);
            }
        }

        protected override void InternalUpdate(TModel obj)
        {
            try
            {
                base.InternalUpdate(obj);
            }
            catch (Prodesp.Core.NHibernate.DAL.Database.Util.PersistenceContextException ex)
            {
                ValidatePersistenceContextException(ex);
            }
        }

        protected override void InternalDelete(TModel obj)
        {
            try
            {
                base.InternalDelete(obj);
            }
            catch (Prodesp.Core.NHibernate.DAL.Database.Util.PersistenceContextException ex)
            {
                ValidatePersistenceContextException(ex);
            }
        }
    }
}
