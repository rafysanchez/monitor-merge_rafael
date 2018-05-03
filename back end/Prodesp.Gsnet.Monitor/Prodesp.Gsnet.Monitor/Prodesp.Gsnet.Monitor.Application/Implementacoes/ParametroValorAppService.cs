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
using Prodesp.Gsnet.Monitor.Domain.DTO;

namespace Prodesp.Gsnet.Monitor.Application.Implementacoes
{
    public class ParametroValorAppService : AppService<ParametroValor, IParametroValorService>, IParametroValorAppService
    {

        public ParametroValorAppService(IParametroValorService service) : base(service)
        {
        }

        public string InserirDados(ParametroDTO dado)
        {
            return this._service.InserirDados(dado);
        }

        public override ValidationResult ValidarAdicicao(ParametroValor entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarAtualizacao(ParametroValor entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarRemocao(ParametroValor entity)
        {
            throw new NotImplementedException();
        }
    }
}
