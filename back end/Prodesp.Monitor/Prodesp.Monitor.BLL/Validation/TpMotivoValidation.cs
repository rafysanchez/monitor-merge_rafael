using FluentValidation;
using Prodesp.Monitor.BLL.Bll;
using Prodesp.Monitor.DAL.Model;

namespace Prodesp.Monitor.BLL.Validation
{
    public class TpMotivoValidation : CustomValidation<TpMotivo>
    {

        public TpMotivoValidation(EventoValidacao e) : base(e)
        {
        }

        private bool IsTpMotivo(TpMotivo data)
        {
            var bll = new TpMotivoBllNHibernate();
            var result = bll.GetById(data.IdMotivo);
            return result != null;
        }

        protected override void SharedValidation()
        {
            RuleFor(model => model.IdMotivo).GreaterThan(0).WithMessage("Campo Motivo não informado");
            RuleFor(model => model.StRegistro).Must(ValidateIsStRegistro).WithMessage("Campo status registro inválido");
            RuleFor(model => model.DtInclusao).Must((ValidateDate)).WithMessage("Campo Data Inclusao não informado ou inválido ");
            RuleFor(model => model.DtAlteracao).Must((ValidateDate)).WithMessage("Campo Data Alteracao não informado ou inválido ");
        }

        protected override void CreateValidation()
        {
            RuleFor(model => model.IdMotivo).Must((model, id) => !IsTpMotivo(model)).WithMessage("Registro já existe");
        }

        protected override void EditValidation()
        {
            RuleFor(model => model.IdMotivo).Must((model, id) => IsTpMotivo(model)).WithMessage("Registro não encontrado");
            RuleFor(model => model.DtAlteracao).NotEmpty().WithMessage("Campo data de alteração não informado");
        }

        protected override void DeleteValidation()
        {
            RuleFor(model => model.IdMotivo).Must((model, id) => IsTpMotivo(model)).WithMessage("Registro não encontrado");
        }
    }
}
