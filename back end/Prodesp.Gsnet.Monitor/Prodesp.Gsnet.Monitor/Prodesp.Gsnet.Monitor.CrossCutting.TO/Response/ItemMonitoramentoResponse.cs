using Prodesp.Gsnet.Core.TO.Response;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels;
using Prodesp.Gsnet.Monitor.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.Response
{
    public class ItemMonitoramentoResponse : IResponseBase //: ListResponse<ItemMonitoramentoDTO>
    {
        public IEnumerable<ItemAlertaMonitorViewModel> Data { get; set; }
        public string DataMonitoramento { get; set; }
        public int IdPrograma { get; set; }
        public int JustificativasPendentes { get; set; }
        public string NomePrograma { get; set; }
        public string Percentual { get; set; }
        public int QuantidadeAlertas { get; set; }
        public int QuantidadeAlertasItens { get; set; }
        public int TotalRecords { get; set; }
        public string Message { get; set; }
        public int QuantidadeItens { get; set; }
        public string TipoConsumoSaldoZerado { get; set; }
        public string TipoConsumoAutonomia { get; set; }
        public int TotalPages { get; set; }

        public bool HasErrors
        {
            get;

            set;
        }
    }
}
