using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Application.Implementacoes;
using Prodesp.Gsnet.Monitor.Application.Interfaces;
using Prodesp.Gsnet.Monitor.Domain.DTO;

namespace Prodesp.Gsnet.Monitor.Application.Implementacoes
{
    public class JustificativaAppService : AppService<Justificativa, IJustificativaService>, IJusticativaAppService
    {
        IMotivoAcaoAppService _motivoAcaoService;
        public JustificativaAppService(IJustificativaService service, IMotivoAcaoAppService motivoAcaoService) : base(service)
        {
            _motivoAcaoService = motivoAcaoService;
        }

        public override ValidationResult Adicionar(Justificativa entity)
        {
            entity.DataInclusao = DateTime.Now;
            entity.DataJustificativa = DateTime.Today;
            return base.Adicionar(entity);
        }
        public ValidationResult AdicionarVarios(IEnumerable<Justificativa> justificativas)
        {
            ValidationResult result = new ValidationResult();
            try
            {
                result = ExecutarQuandoForValido(justificativas, () => this.ValidarAdicicao(justificativas), () => this._service.AdicionarVarios(justificativas));
            }
            catch (Exception e)
            {

                result.Add(e.Message);
            }
            return result;
        }

        public Justificativa BuscarPorItemMonitoramento(int id, int idJustificador)
        {
            return this._service.BuscarPorItemMonitoramento(id, idJustificador);
        }

        public ValidationResult JustificarPorPrograma(int idPrograma, int idJustificador, MotivoAcao motivo, MotivoAcao acao)
        {
            ValidationResult result = new ValidationResult();
            try
            {
                this._service.JustificarPorPrograma(idPrograma, idJustificador, motivo, acao);
            }
            catch (Exception e)
            {

                result.Add(e.Message);
            }
            return result;
        }

        public IEnumerable<Justificativa> BuscarUltimasJustificativas(int idItem, int idJustificador, int idGestor)
        {
            return this._service.BuscarUltimasJustificativas(idItem, idJustificador, idGestor);
        }

        public ValidationResult DeletarVarios(IEnumerable<Justificativa> justificativas)
        {
            ValidationResult result = new ValidationResult();
            try
            {
                this._service.DeletarVarios(justificativas);
            }
            catch (Exception e)
            {

                result.Add(e.Message);
            }
            return result;
        }

        public ValidationResult UsarJustificativaAnterior(IEnumerable<Justificativa> justificativas)
        {
            ValidationResult result = new ValidationResult();
            try
            {
                this._service.UsarJustificativaAnterior(justificativas);
            }
            catch (Exception e)
            {
                result.Add(e.Message);
            }
            return result;
        }
        public ValidationResult ValidarAdicicao(IEnumerable<Justificativa> entity)
        {
            ValidationResult result = new ValidationResult();
            foreach (var item in entity)
            {
                result = this.ValidarAdicicao(item);
                if (!result.IsValid)
                    break;
            }
            return result;

        }
        public override ValidationResult ValidarAdicicao(Justificativa entity)
        {
            ValidationResult result = new ValidationResult();

            try
            {
                entity.DataInclusao = DateTime.Now;
                entity.Acao = null; entity.Motivo = null;
                MotivoAcao motivo = _motivoAcaoService.BuscarPorId(entity.IdMotivo);
                MotivoAcao acao = _motivoAcaoService.BuscarPorId(entity.IdAcao);
                if ((motivo?.ValidarObrigatoriedadeComplementoDescricao()).GetValueOrDefault() && string.IsNullOrEmpty(entity.MotivoJustificativa))
                {
                    throw new Exception("Descrição do motivo é obrigatória");
                }
                if ((acao?.ValidarObrigatoriedadeComplementoDescricao()).GetValueOrDefault() && string.IsNullOrEmpty(entity.AcaoJustificativa))
                {
                    throw new Exception("Descrição da ação é obrigatória");
                }
            }
            catch (Exception e)
            {
                result.Add(e.Message);
            }

            return result;

        }

        public override ValidationResult ValidarAtualizacao(Justificativa entity)
        {
            ValidationResult result = new ValidationResult();
            entity.DataAlteracao = DateTime.Now;
            return result;
        }

        public override ValidationResult ValidarRemocao(Justificativa entity)
        {
            throw new NotImplementedException();
        }

        public ValidationResult UsarJustificativaAnterior(Justificativa justificativas)
        {
            ValidationResult result = new ValidationResult();
            try
            {
                this._service.UsarJustificativaAnterior(justificativas);
            }
            catch (Exception e)
            {
                result.Add(e.Message);
                // throw;
            }
            return result;
        }

        public IEnumerable<HistoricoJustificativaDTO> BuscarHistoricoJustificativas(int idPrograma, int idGsnet, int idGestor)
        {
            return this._service.BuscarHistoricoJustificativas(idPrograma, idGsnet,idGestor);
        }
    }


}
