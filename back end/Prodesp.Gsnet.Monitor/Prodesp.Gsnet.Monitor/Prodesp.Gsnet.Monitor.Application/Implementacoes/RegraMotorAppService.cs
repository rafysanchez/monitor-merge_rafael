using Prodesp.Gsnet.Monitor.Application.Interfaces;
using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using System;


namespace Prodesp.Gsnet.Monitor.Application.Implementacoes
{
    public class RegraMotorAppService : AppService<RegraMotor, IRegraMotorService>, IRegraMotorAppService
    {
        public RegraMotorAppService(IRegraMotorService service) : base(service)
        {

        }
        RegraMotor IRegraMotorAppService.InserirDados(ParametroDTO dado)
        {
            return this._service.InserirDados(dado);

        }

        public override ValidationResult ValidarAdicicao(RegraMotor entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarAtualizacao(RegraMotor entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarRemocao(RegraMotor entity)
        {
            throw new NotImplementedException();
        }
    }
}
