using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Monitor.Domain.Entidades;

namespace Prodesp.Gsnet.Monitor.Application.Interfaces
{
    public interface IParametroValorAppService : IAppService<ParametroValor>
    {
        string InserirDados(ParametroDTO dado);
    }
}
