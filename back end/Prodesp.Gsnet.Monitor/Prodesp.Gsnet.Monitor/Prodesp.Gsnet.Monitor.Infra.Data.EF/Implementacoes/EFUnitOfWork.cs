using Prodesp.Gsnet.Monitor.Domain.Extensions;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Implementacoes
{
    public class EFUnitOfWork : IUnitOfWork
    {
        protected Contexto _context;
        public EFUnitOfWork()
        {
            this.Contexto = new Contexto();
        }
        public Contexto Contexto
        {
            get;set;
        }

        public void Dispose()
        {
            this.Contexto.Dispose();
        }
        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Dispose();
                }
            }
            this.disposed = true;
        }

        public object GetSession()
        {
            return this.Contexto;
        }

        public ValidationResult Save()
        {
            ValidationResult result = new ValidationResult();
            try
            {
                this.Contexto.SaveChanges();                
            }
            catch (DbEntityValidationException e)
            {
                string msg = string.Join(Environment.NewLine, e.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                result.Add(msg);               
            }
            catch(Exception ex)
            {
                result.Add(ex.GetaAllMessages());
            }
            return result;
        }
    }
}
