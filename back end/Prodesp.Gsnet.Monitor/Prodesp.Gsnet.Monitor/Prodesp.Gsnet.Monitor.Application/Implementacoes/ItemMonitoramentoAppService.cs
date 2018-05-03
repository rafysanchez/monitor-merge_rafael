using Prodesp.Gsnet.Monitor.Application.Interfaces;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Domain.DTO;
using System.Linq.Expressions;

namespace Prodesp.Gsnet.Monitor.Application.Implementacoes
{
    public class ItemMonitoramentoAppService : AppService<ItemMonitoramento, IItemMonitoramentoService>, IItemMonitoramentoAppService
    {
        public ItemMonitoramentoAppService(IItemMonitoramentoService service) : base(service)
        {
        }

        public SearchResult<ItemMonitoramentoDTO> Buscar(Expression<Func<ItemMonitoramentoDTO, bool>> condition, string orderBy = "", string sortDirection = "", int take = 0, int skip = 0)
        {
            return this._service.Buscar(condition, orderBy, sortDirection, take, skip);
        }

        public IEnumerable<ItemMonitoramentoDTO> BuscarPorMonitoramento(int idMonitoramento)
        {
            return this._service.BuscarPorMonitoramento(idMonitoramento);
        }

        public override ValidationResult ValidarAdicicao(ItemMonitoramento entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarAtualizacao(ItemMonitoramento entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarRemocao(ItemMonitoramento entity)
        {
            throw new NotImplementedException();
        }
    }
}
