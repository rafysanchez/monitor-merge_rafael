using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Monitor.Domain.Entidades;

namespace Prodesp.Gsnet.Monitor.Application.Interfaces
{
    public interface IRegraMotorAppService : IAppService<RegraMotor>
    {
        RegraMotor InserirDados(ParametroDTO dado);
    }
}
