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
using Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels;
using Prodesp.Gsnet.Monitor.Domain.DTO;

namespace Prodesp.Gsnet.Monitor.Application.Implementacoes
{
   public  class ParametroAppService : AppService<Parametro, IParametroService>, IParametroAppService
    {
        public ParametroAppService(IParametroService service) : base(service)
        { }


        List<DadosViewDetalheConsumo> IParametroAppService.retDadosViewDetalheConsumo()
        {
            return this._service.retDadosViewDetalheConsumo();
        }
        

        public override ValidationResult ValidarAdicicao(Parametro entity)
        {
            throw new NotImplementedException();


        }

        public override ValidationResult ValidarAtualizacao(Parametro entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarRemocao(Parametro entity)
        {
            throw new NotImplementedException();
        }

    }
    
}
