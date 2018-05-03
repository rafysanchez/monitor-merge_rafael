using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios;
using Prodesp.Gsnet.Monitor.Infra.Data.EF.Implementacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data;
using Prodesp.Gsnet.Monitor.Domain.DTO;

namespace Prodesp.Gsnet.Monitor.Infra.Data.Repository
{
    public class JustificativaRepository : EFRepository<Justificativa>, IJustificativaRepository
    {
        public JustificativaRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public void AdicionarVarios(IEnumerable<Justificativa> justificativas)
        {
            foreach (Justificativa justificativa in justificativas)
            {
                this.Adicionar(justificativa);
            }
        }
        public Justificativa BuscarPorItemMonitoramento(long id, int idJustificador)
        {
            return this._contexto.Justificativas.FirstOrDefault(x => x.IdItemMonitoramento == id && x.IdJustificador == idJustificador);
        }
        public bool EstaJustificado(long idItem, int idJustificador)
        {
            var query = (
                            from itm in this._contexto.ItensMonitoramentos
                            join j in this._contexto.Justificativas on itm.Id equals j.IdItemMonitoramento
                            join m in this._contexto.Monitoramentos on itm.IdMonitoramento equals m.Id
                            where itm.Id == idItem && j.IdJustificador == idJustificador && m.FlagAtivo == "S"
                            select 1
                           ).Any();
            return query;
        }
        public Justificativa BuscarJustificativaAnterior(int idItemGsnet, int idJustificador, int idGestor)
        {
            var query = (
                            from itm in this._contexto.ItensMonitoramentos
                            join ipg in this._contexto.ItensProgramaGestor on itm.IdItemProgramaGestor equals ipg.Id
                            join ips in this._contexto.ItensProgramaSaude on ipg.IdItemPrograma equals ips.Id
                            join item in this._contexto.Itens on ips.IdItem equals item.Id
                            join j in this._contexto.Justificativas on itm.Id equals j.IdItemMonitoramento
                            join m in this._contexto.Monitoramentos on itm.IdMonitoramento equals m.Id
                            where item.IdGsnet == idItemGsnet && j.IdJustificador == idJustificador && m.FlagAtivo == "N" && ipg.IdGestor == idGestor
                            select j
                           ).OrderByDescending(x => x.DataJustificativa).FirstOrDefault();
            return query;
        }

        public IEnumerable<Justificativa> BuscarUltimasJustificativas(int idItem, int idJustificador, int idGestor)
        {
            var query = (
                         from itm in this._contexto.ItensMonitoramentos
                         join ipg in this._contexto.ItensProgramaGestor on itm.IdItemProgramaGestor equals ipg.Id
                         join ips in this._contexto.ItensProgramaSaude on ipg.IdItemPrograma equals ips.Id
                         join item in this._contexto.Itens on ips.IdItem equals item.Id
                         from j in this._contexto.Justificativas.Where(x => x.IdItemMonitoramento == itm.Id && x.IdJustificador == idJustificador)
                         join m in this._contexto.Monitoramentos on itm.IdMonitoramento equals m.Id
                         where item.IdGsnet == idItem && ipg.IdGestor == idGestor && m.FlagAtivo == "N" && j.IdJustificador == idJustificador
                         select j
                        )
                        .OrderByDescending(x => x.DataJustificativa)
                        .Take(2)
                        .ToList();
            return query;
        }

        public void DeletarVarios(IEnumerable<Justificativa> justificativas)
        {
            Justificativa justificativaDeletada;

            foreach (var justificativa in justificativas)
            {
                justificativaDeletada = this.BuscarPorId(justificativa.Id);
            }
        }

        public void UsarJustificativaAnterior(IEnumerable<Justificativa> justificativas)
        {
            Justificativa justificativaDeletada;

            foreach (var justificativa in justificativas)
            {
                //justificativaDeletada = this.BuscarPorId()
            }
        }

        public Justificativa BuscarUltimaJustificativa(int idItemGsnet, int idJustificador, int idGestor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Justificativa> BuscarPorPrograma(int idPrograma, int idJustificador)
        {
            var query = (
                           from itm in this._contexto.ItensMonitoramentos
                           join ipg in this._contexto.ItensProgramaGestor on itm.IdItemProgramaGestor equals ipg.Id
                           join ips in this._contexto.ItensProgramaSaude on ipg.IdItemPrograma equals ips.Id
                           join item in this._contexto.Itens on ips.IdItem equals item.Id
                           join j in this._contexto.Justificativas on itm.Id equals j.IdItemMonitoramento
                           join m in this._contexto.Monitoramentos on itm.IdMonitoramento equals m.Id
                           where m.IdPrograma == idPrograma && j.IdJustificador == idJustificador && m.FlagAtivo == "S"
                           select j
                          ).ToList();
            return query;
        }

        public IEnumerable<HistoricoJustificativaDTO> BuscarHistoricoJustificativas(int idPrograma, int idGsnet, int idGestor)
        {
            var query = (
                           from itm in this._contexto.ItensMonitoramentos
                           join ipg in this._contexto.ItensProgramaGestor on itm.IdItemProgramaGestor equals ipg.Id
                           join ips in this._contexto.ItensProgramaSaude on ipg.IdItemPrograma equals ips.Id
                           join item in this._contexto.Itens on ips.IdItem equals item.Id
                           join m in this._contexto.Monitoramentos on itm.IdMonitoramento equals m.Id
                           //from jFME in this._contexto.Justificativas.Where(x => x.IdItemMonitoramento == itm.Id && x.IdJustificador == 1).DefaultIfEmpty()
                           //from jCAF in this._contexto.Justificativas.Where(x => x.IdItemMonitoramento == itm.Id && x.IdJustificador == 2).DefaultIfEmpty()
                           //from jCompras in this._contexto.Justificativas.Where(x => x.IdItemMonitoramento == itm.Id && x.IdJustificador == 3).DefaultIfEmpty()
                           //from jCAFPublica in this._contexto.Justificativas.Where(x => x.IdItemMonitoramento == itm.Id && x.IdJustificador == 4).DefaultIfEmpty()
                           join g in this._contexto.Gestores on ipg.IdGestor equals g.Id
                           where m.IdPrograma == idPrograma && ipg.IdGestor == idGestor && item.IdGsnet == idGsnet && ipg.IdGestor == idGestor
                           && (this._contexto.Justificativas.Where(x => x.IdItemMonitoramento == itm.Id)).Any()
                           select new HistoricoJustificativaDTO
                           {
                               IdItemMonitoramento = itm.Id,
                               DataMonitoramento = m.DataMonitoramento,
                               DataUltimaFatura = itm.DataUltimaFatura,
                               DataUltimoEmpenho = itm.DataUltimoEmpenho,
                               ConsumoMedex = itm.QuantidadeConsumo,
                               DataInicioVigencia = m.DataInicioVigencia,
                               //JustificativaFME = jFME,
                               //JustificativaCAF = jCAF,
                               //JustificativaCompras = jCompras,
                               //JustificativaCAFPublica = jCAFPublica,
                               SaldoDisponivel = itm.QuantidadeSaldoDisponivel,
                               TipoConsumo = itm.TipoConsumo
                           }
                          ).OrderByDescending(X => X.DataMonitoramento).ToList();
            var group = query.GroupBy(x => new { x.DataMonitoramento, x.DataInicioVigencia, x.DataUltimaFatura, x.DataUltimoEmpenho, x.SaldoDisponivel, x.TipoConsumo, x.ConsumoMedex, x.IdItemMonitoramento }, (g, itens) =>
               new HistoricoJustificativaDTO
               {
                   DataMonitoramento = g.DataMonitoramento.GetValueOrDefault(),
                   DataUltimaFatura = g.DataUltimaFatura,
                   DataInicioVigencia = g.DataInicioVigencia,
                   DataUltimoEmpenho = g.DataUltimoEmpenho,
                   SaldoDisponivel = g.SaldoDisponivel,
                   TipoConsumo = g.TipoConsumo,
                   ConsumoMedex = g.ConsumoMedex,
                   JustificativaCAF = this._contexto.Justificativas.FirstOrDefault(x => x.IdItemMonitoramento == g.IdItemMonitoramento && x.IdJustificador == 2),
                   JustificativaCAFPublica = this._contexto.Justificativas.FirstOrDefault(x => x.IdItemMonitoramento == g.IdItemMonitoramento && x.IdJustificador == 4),
                   JustificativaCompras = this._contexto.Justificativas.FirstOrDefault(x => x.IdItemMonitoramento == g.IdItemMonitoramento && x.IdJustificador == 3),
                   JustificativaFME = this._contexto.Justificativas.FirstOrDefault(x => x.IdItemMonitoramento == g.IdItemMonitoramento && x.IdJustificador == 1),
               });           
            return group.ToArray();
        }
    }
}
