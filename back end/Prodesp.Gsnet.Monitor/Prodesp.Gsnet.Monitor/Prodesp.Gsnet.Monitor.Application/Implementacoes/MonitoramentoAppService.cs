using Prodesp.Gsnet.Monitor.Application.Interfaces;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;

namespace Prodesp.Gsnet.Monitor.Application.Implementacoes
{
    public class MonitoramentoAppService : AppService<Monitoramento, IMonitoramentoService>, IMonitoramentoAppService
    {
        public MonitoramentoAppService(IMonitoramentoService service) : base(service)
        {
        }

        public override ValidationResult ValidarAdicicao(Monitoramento entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarAtualizacao(Monitoramento entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarRemocao(Monitoramento entity)
        {
            throw new NotImplementedException();
        }
    }
}
