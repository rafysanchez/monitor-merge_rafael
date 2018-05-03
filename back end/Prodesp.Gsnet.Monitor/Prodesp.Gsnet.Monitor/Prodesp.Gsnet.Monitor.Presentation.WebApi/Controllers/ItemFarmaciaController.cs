using Prodesp.Gsnet.Monitor.Application.Interfaces;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.CrossCutting;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data;
using Prodesp.Gsnet.Monitor.Domain;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.Requests;
using Prodesp.Gsnet.Monitor.Domain.DTO;

namespace Prodesp.Gsnet.Monitor.Presentation.WebApi.Controllers
{
    public class ItemFarmaciaController : BaseController<Item, ItemViewModel, IItemAppService>
    {
        public ItemFarmaciaController(IItemAppService service, IEntityTypeConverter<Item, ItemViewModel> entityConverter, IUnitOfWork unitOfWork)
            : base(service, entityConverter, unitOfWork)
        {
        }


        [HttpGet]
        [Route("api/itemfarmacia/retListagemFarmacia")]
        public HttpResponseMessage retListagemFarmacia()
        {
            // mon_item_programa_saude
            // mon_itens
            // mon_unidade_medida

            var lista = new ListDadosFarmaciaDTO();





            return null;

        }
    }
}