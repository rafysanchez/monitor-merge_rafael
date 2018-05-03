using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos
{
    public interface IJustificativaService : IService<Justificativa>
    {
        void AdicionarVarios(IEnumerable<Justificativa> justificativas);
        void DeletarVarios(IEnumerable<Justificativa> justificativas);
        IEnumerable<Justificativa> BuscarUltimasJustificativas(int idItem, int idJustificador,int idGestor);
        Justificativa BuscarPorItemMonitoramento(int id, int idJustificador);
        void UsarJustificativaAnterior(IEnumerable<Justificativa> justificativas);
        void UsarJustificativaAnterior(Justificativa justificativas);
        Justificativa BuscarJustificativaAnterior(int idItemGsnet, int idJustificador, int idGestor);
        Justificativa BuscarUltimaJustificativa(int idItemGsnet, int idJustificador, int idGestor);
        void JustificarPorPrograma(int idPrograma, int idJustificador, MotivoAcao motivo, MotivoAcao acao);
        IEnumerable<HistoricoJustificativaDTO> BuscarHistoricoJustificativas(int idPrograma, int idGsnet, int idGestor);


    }
}
