using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Application.Interfaces
{
    public interface IJusticativaAppService : IAppService<Justificativa>
    {
        ValidationResult AdicionarVarios(IEnumerable<Justificativa> justificativas);
        ValidationResult DeletarVarios(IEnumerable<Justificativa> justificativas);
        IEnumerable<Justificativa> BuscarUltimasJustificativas(int idItem, int idJustificador, int idGestor);
        Justificativa BuscarPorItemMonitoramento(int id, int idJustificador);
        ValidationResult UsarJustificativaAnterior(IEnumerable<Justificativa> justificativas);
        ValidationResult UsarJustificativaAnterior(Justificativa justificativas);
        ValidationResult JustificarPorPrograma(int idPrograma, int idJustificador, MotivoAcao motivo, MotivoAcao acao);
        IEnumerable<HistoricoJustificativaDTO> BuscarHistoricoJustificativas(int idPrograma, int idGsnet,int idGestor);


    }
}
