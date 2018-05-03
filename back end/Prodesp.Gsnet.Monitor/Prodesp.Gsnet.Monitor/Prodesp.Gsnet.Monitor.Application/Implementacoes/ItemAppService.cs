using Prodesp.Gsnet.Monitor.Application.Interfaces;
using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Servicos;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using System;

namespace Prodesp.Gsnet.Monitor.Application.Implementacoes
{
   public class ItemAppService : AppService<Item, IItemService>, IItemAppService
    {
        public ItemAppService(IItemService service) : base(service)
        {
        }

        public override ValidationResult ValidarAdicicao(Item entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarAtualizacao(Item entity)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult ValidarRemocao(Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
