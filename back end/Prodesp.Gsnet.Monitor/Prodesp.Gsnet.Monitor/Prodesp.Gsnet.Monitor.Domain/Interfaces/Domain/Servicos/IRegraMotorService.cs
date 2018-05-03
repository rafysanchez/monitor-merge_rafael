using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Monitor.Domain.Entidades;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos
{
    public interface IRegraMotorService : IService<RegraMotor>
    {

        RegraMotor InserirDados(ParametroDTO dado);
    }
}
