using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.DTO
{
   public  class DadosViewDetalheConsumo
    {
        public int Id { get; set; }
        public int IdRegraMotor { get; set; }
        public string NomeParametro { get; set; }
        public string ValorParametro { get; set; }
    }
}
