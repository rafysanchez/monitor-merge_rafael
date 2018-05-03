using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.DTO;

namespace Prodesp.Gsnet.Monitor.Domain.Implementacoes.Domain.Servicos
{
    public class ParametroService : ServiceBase<Parametro, IParametroRepository>, IParametroService
    {
        public ParametroService(IParametroRepository repository) : base(repository)
        {

        }

        List<DadosViewDetalheConsumo> IParametroService.retDadosViewDetalheConsumo()
        {
            return this._repository.retDadosViewDetalheConsumo();
        }

        
    }
}
