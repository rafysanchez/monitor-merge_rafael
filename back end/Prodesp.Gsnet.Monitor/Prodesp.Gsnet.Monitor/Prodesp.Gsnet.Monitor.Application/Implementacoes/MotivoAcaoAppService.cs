using Prodesp.Gsnet.Monitor.Application.Interfaces;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Domain;

namespace Prodesp.Gsnet.Monitor.Application.Implementacoes
{
    public class MotivoAcaoAppService : AppService<MotivoAcao, IMotivoAcaoService>, IMotivoAcaoAppService
    {
        public MotivoAcaoAppService(IMotivoAcaoService service) : base(service)
        {
        }

        public IEnumerable<MotivoAcao> BuscarPorTipo(MotivoAcaoEnum tipo)
        {
            return this._service.BuscarPorTipo(tipo);
        }

        public override ValidationResult ValidarAdicicao(MotivoAcao entity)
        {
            entity.DataInclusao = DateTime.Now;
            entity.IdUsuarioInclusao = 100;
            // se a justificativa nao puder ser editada , entao automaticamente a justificativa nao é obrigatória
            if(entity.PodeEditarJustificativa == 0)
            {
                entity.JustificativaObrigatoria = 0;
            }
            return new ValidationResult();


        }

        public override ValidationResult ValidarAtualizacao(MotivoAcao entity)
        {
            entity.DataAlteracao = DateTime.Now;
            // se a justificativa nao puder ser editada , entao automaticamente a justificativa nao é obrigatória
            if (entity.PodeEditarJustificativa == 0)
            {
                entity.JustificativaObrigatoria = 0;
            }
            return new ValidationResult();
        }

        public override ValidationResult ValidarRemocao(MotivoAcao entity)
        {
            throw new NotImplementedException();
        }
    }
}
