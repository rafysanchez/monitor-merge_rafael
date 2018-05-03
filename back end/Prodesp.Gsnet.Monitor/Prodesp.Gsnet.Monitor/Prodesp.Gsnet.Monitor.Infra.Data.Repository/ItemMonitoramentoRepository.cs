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
using System.Linq.Expressions;
using Prodesp.Gsnet.Monitor.Infra.Data.EF.Helpers;
using System.Data.Entity;

namespace Prodesp.Gsnet.Monitor.Infra.Data.Repository
{
    public class ItemMonitoramentoRepository : EFRepository<ItemMonitoramento>, IItemMonitoramentoRepository
    {
        public ItemMonitoramentoRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public SearchResult<ItemMonitoramentoDTO> Buscar(Expression<Func<ItemMonitoramentoDTO, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0)
        {
            var query = QueryBase().Where(condition);
            int totalRecords = query.Count();
            if (!string.IsNullOrEmpty(orderBy))
            {
                if (sortDirection == "asc")
                    query = OrderByHelper.OrderBy(query, orderBy);
                else
                    query = OrderByHelper.OrderByDescending(query, orderBy);

                if (take > 0)
                    query = query.Take(take);
                if (skip > 0)
                    query = query.Skip(skip);
            }

          

            return new SearchResult<ItemMonitoramentoDTO>
            {
                Itens = query.ToList(),
                TotalRecords = totalRecords,
                RecordsPerPage = take
            };
        }

        public IEnumerable<ItemMonitoramentoDTO> BuscarPorMonitoramento(int idMonitoramento)
        {
            var query = this.QueryBase().ToList();

            return query;
        }

        public IEnumerable<ItemMonitoramentoDTO> BuscarPorPrograma(int idPrograma)
        {
            var query = this.QueryBase().Where(x => x.IdPrograma == idPrograma);
            return query.ToList();
        }

        public IQueryable<ItemMonitoramentoDTO> QueryBase()
        {
            var query = (from itm in this._contexto.ItensMonitoramentos
                         join ipg in this._contexto.ItensProgramaGestor on itm.IdItemProgramaGestor equals ipg.Id
                         join ips in this._contexto.ItensProgramaSaude on ipg.IdItemPrograma equals ips.Id
                         join item in this._contexto.Itens on ips.IdItem equals item.Id
                         join unid in this._contexto.UnidadesMedida on item.IdUnidadeMedida equals unid.Id
                         join gest in this._contexto.Gestores on ipg.IdGestor equals gest.Id
                         join m in this._contexto.Monitoramentos on itm.IdMonitoramento equals m.Id
                         //  where m.FlagAtivo == "S"
                         select new ItemMonitoramentoDTO
                         {
                             Id = itm.Id,
                             IdMonitoramento = itm.IdMonitoramento,
                             IdPrograma = m.IdPrograma,                             
                             DataMonitoramento = m.DataMonitoramento,
                             FlagAtivo = m.FlagAtivo,
                             Nome = item.Nome,
                             IdGestorMonitor = gest.Id,
                             IdItemGsnet = item.IdGsnet,
                             CodigoSIAFISICO = item.CodigoSIAFISICO,
                             CodigoMedicamento = item.CodigoMedicamento,
                             QuantidadeConsumo = itm.QuantidadeConsumo,
                             QuantidadeDiasAutonomia = itm.QuantidadeDiasAutonomia,
                             QuantidadeSaldoDisponivel = itm.QuantidadeSaldoDisponivel,
                             QuantidadeUltimaFatura = itm.QuantidadeUltimaFatura,
                             QuantidadeUltimoConsumo = itm.QuantidadeUltimoConsumo,
                             QuantidadeUltimoEmpenho = itm.QuantidadeUltimoEmpenho,
                             DataUltimaFatura = itm.DataUltimaFatura,
                             DataUltimoConsumo = itm.DataUltimoConsumo,
                             DataUltimoEmpenho = itm.DataUltimoEmpenho,
                             GrupoRecursos = ips.CodigoGrupoRecurso,
                             Local = gest.Sigla,
                             TipoConsumo = itm.TipoConsumo,
                             TipoRegra = itm.TipoRegra,
                             UnidadeDistribuicao = unid.Nome,
                             JustificadoFME = this._contexto.Justificativas.Any(x => x.IdItemMonitoramento == itm.Id && x.IdJustificador == 1),
                             JustificadoCAF = this._contexto.Justificativas.Any(x => x.IdItemMonitoramento == itm.Id && x.IdJustificador == 2),
                             JustificadoCMP = this._contexto.Justificativas.Any(x => x.IdItemMonitoramento == itm.Id && x.IdJustificador == 3),
                             JustificadoCAFPublica = this._contexto.Justificativas.Any(x => x.IdItemMonitoramento == itm.Id && x.IdJustificador == 4),
                         });
            return query;
        }
    }
}
