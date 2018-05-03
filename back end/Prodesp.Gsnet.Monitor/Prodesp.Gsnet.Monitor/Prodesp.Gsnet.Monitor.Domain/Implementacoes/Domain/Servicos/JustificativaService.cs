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
    public class JustificativaService : ServiceBase<Justificativa, IJustificativaRepository>, IJustificativaService
    {
        IItemMonitoramentoRepository _itemMonitoramentoRepository;
        public JustificativaService(IJustificativaRepository repository, IItemMonitoramentoRepository itemMonitoramentoRepository) : base(repository)
        {
            _itemMonitoramentoRepository = itemMonitoramentoRepository;
        }

        public void AdicionarVarios(IEnumerable<Justificativa> justificativas)
        {
            foreach (var justificativa in justificativas)
            {

                bool justificado = this._repository.EstaJustificado(justificativa.IdItemMonitoramento, justificativa.IdJustificador);
                if (justificado)
                    throw new NotSupportedException("Alguns dos itens selecionados já foram justificados. Verifique os itens selecionados");
            }
            this._repository.AdicionarVarios(justificativas);
        }

        public Justificativa BuscarPorItemMonitoramento(int id, int idJustificador)
        {
            return this._repository.BuscarPorItemMonitoramento(id, idJustificador);
        }

        public Justificativa BuscarJustificativaAnterior(int idItemGsnet, int idJustificador, int idGestor)
        {
            return this._repository.BuscarJustificativaAnterior(idItemGsnet, idJustificador, idGestor);
        }

        public IEnumerable<Justificativa> BuscarUltimasJustificativas(int idItem, int idJustificador, int idGestor)
        {
            return this._repository.BuscarUltimasJustificativas(idItem, idJustificador, idGestor);
        }

        public void DeletarVarios(IEnumerable<Justificativa> justificativas)
        {
            Justificativa deletarJustificativa;
            foreach (var justificativa in justificativas)
            {
                deletarJustificativa = this._repository.BuscarPorItemMonitoramento(justificativa.IdItemMonitoramento, justificativa.IdJustificador);

                if (deletarJustificativa != null)
                {
                    this._repository.Apagar(deletarJustificativa);
                    // caso o justificador seja CAF, entao deve-se buscar a justificativa tambem da CAF Publica e deletar tambem (caso exista)
                    // Regra aprovada por cinthia penetta em 21/03/2018                    
                    if (deletarJustificativa.IdJustificador == 2)
                    {
                        var justificativaCAFPublica = this._repository.BuscarPorItemMonitoramento(justificativa.IdItemMonitoramento, 4);
                        if (justificativaCAFPublica != null)
                        {
                            this._repository.Apagar(justificativaCAFPublica);
                        }
                    }
                }
                else
                {
                    throw new NotSupportedException("Alguns dos itens selecionados não estão justificados. Verifique os itens selecionados");
                }
            }
        }

        public void UsarJustificativaAnterior(IEnumerable<Justificativa> justificativas)
        {
            Justificativa anterior;
            foreach (var justificativa in justificativas)
            {
                bool justificado = this._repository.EstaJustificado(justificativa.IdItemMonitoramento, justificativa.IdJustificador);
                if (justificado)
                    throw new NotSupportedException("Alguns dos itens selecionados já foram justificados. Verifique os itens selecionados");

                anterior = this._repository.BuscarJustificativaAnterior(justificativa.IdItemGsnet, justificativa.IdJustificador, justificativa.IdGestorMonitor);

                if (anterior != null)
                {
                    justificativa.IdAcao = anterior.IdAcao;
                    justificativa.AcaoJustificativa = anterior.AcaoJustificativa;
                    justificativa.IdMotivo = anterior.IdMotivo;
                    justificativa.MotivoJustificativa = anterior.MotivoJustificativa;
                    justificativa.DataInclusao = DateTime.Now;
                    justificativa.DataJustificativa = DateTime.Now;
                }
                else
                {
                    throw new NotSupportedException("Alguns dos itens selecionados não possuem justificativa anterior. Verifique os itens selecionados");
                }
            }
            this.AdicionarVarios(justificativas);
        }

        public Justificativa BuscarUltimaJustificativa(int idItemGsnet, int idJustificador, int idGsnet)
        {
            throw new NotImplementedException();
        }

        public void JustificarPorPrograma(int idPrograma, int idJustificador, MotivoAcao motivo, MotivoAcao acao)
        {
            var itens = this._itemMonitoramentoRepository.BuscarPorPrograma(idPrograma);

            IList<Justificativa> justificativas = new List<Justificativa>();

            foreach (var item in itens)
            {
                bool justificado = this._repository.EstaJustificado(item.IdItemGsnet, idJustificador);
                if (justificado)
                    throw new NotSupportedException("Alguns dos itens selecionados já foram justificados. Verifique os itens selecionados");

                justificativas.Add(new Justificativa
                {
                    IdItemMonitoramento = item.Id,
                    AcaoJustificativa = acao.Descricao,
                    IdAcao = acao.Id,
                    MotivoJustificativa = motivo.Descricao,
                    IdMotivo = motivo.Id,
                    IdJustificador = idJustificador,
                    DataInclusao = DateTime.Now,
                    Motivo = null,
                    Acao = null
                });
            }
            this._repository.AdicionarVarios(justificativas);
        }

        public void UsarJustificativaAnterior(Justificativa justificativas)
        {
            bool justificado = this._repository.EstaJustificado(justificativas.IdItemMonitoramento, justificativas.IdJustificador);
            if (justificado)
                throw new NotSupportedException("Esse item já foi justificado");

            var anterior = this._repository.BuscarJustificativaAnterior(justificativas.IdItemGsnet, justificativas.IdJustificador, justificativas.IdGestorMonitor);

            if (anterior != null)
            {
                justificativas.IdAcao = anterior.IdAcao;
                justificativas.AcaoJustificativa = anterior.AcaoJustificativa;
                justificativas.Motivo = null;
                justificativas.Acao = null;

                justificativas.IdMotivo = anterior.IdMotivo;
                justificativas.MotivoJustificativa = anterior.MotivoJustificativa;
                justificativas.DataJustificativa = DateTime.Now;
                justificativas.DataInclusao = DateTime.Now;
                this.Adicionar(justificativas);
            }
            else
            {
                throw new NotSupportedException("Não existe justificativa anterior para este item. ");
            }
        }

        public IEnumerable<HistoricoJustificativaDTO> BuscarHistoricoJustificativas(int idPrograma, int idGsnet, int idGestor)
        {
            return this._repository.BuscarHistoricoJustificativas(idPrograma, idGsnet, idGestor);
        }

    }
}
