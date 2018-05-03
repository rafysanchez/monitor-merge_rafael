using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Monitor.Domain.Entidades;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos
{
    public interface IParametroValorService : IService<ParametroValor>
    {
        string InserirDados(ParametroDTO dado);

    }
}
