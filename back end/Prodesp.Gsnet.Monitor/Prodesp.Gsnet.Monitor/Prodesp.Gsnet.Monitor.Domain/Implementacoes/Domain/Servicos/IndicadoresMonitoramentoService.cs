using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Implementacoes.Domain.Servicos
{
    public class IndicadoresMonitoramentoService : ServiceBase<IndicadoresMonitoramento, IIndicadoresMonitoramentoRepository>, IIndicadoresMonitoramentoService
    {
        public IndicadoresMonitoramentoService(IIndicadoresMonitoramentoRepository repository) : base(repository)
        {
        }
    }
}
