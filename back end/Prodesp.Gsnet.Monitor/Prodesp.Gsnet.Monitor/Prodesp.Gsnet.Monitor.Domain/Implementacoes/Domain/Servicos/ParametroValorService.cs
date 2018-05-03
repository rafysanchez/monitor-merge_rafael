using Prodesp.Gsnet.Monitor.Domain.DTO;
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
   public class ParametroValorService : ServiceBase<ParametroValor, IParametroValorRepository>, IParametroValorService
    {
        public ParametroValorService(IParametroValorRepository repository) : base(repository)
        {
        }
        string IParametroValorService.InserirDados(ParametroDTO dado)
        {
            return this._repository.InserirDados(dado);

        }
    }
}
