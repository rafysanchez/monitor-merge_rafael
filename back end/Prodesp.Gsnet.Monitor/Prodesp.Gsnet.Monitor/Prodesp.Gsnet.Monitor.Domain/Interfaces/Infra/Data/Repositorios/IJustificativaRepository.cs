using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios
{
    public interface IJustificativaRepository : IRepository<Justificativa> 
    {
        void AdicionarVarios(IEnumerable<Justificativa> justificativas);
        void DeletarVarios(IEnumerable<Justificativa> justificativas);
        IEnumerable<Justificativa> BuscarUltimasJustificativas(int idItem, int idJustificador, int idGestor);
        IEnumerable<Justificativa> BuscarPorPrograma(int idPrograma, int idJustificador);
        Justificativa BuscarPorItemMonitoramento(long id, int idJustificador);
        Justificativa BuscarJustificativaAnterior(int idItemGsnet, int idJustificador, int idGestor);
        Justificativa BuscarUltimaJustificativa(int idItemGsnet, int idJustificador, int idGestor);
        bool EstaJustificado(long idItem, int idJustificador);
        IEnumerable<HistoricoJustificativaDTO> BuscarHistoricoJustificativas(int idPrograma, int idGsnet, int idGestor);

    }
}
