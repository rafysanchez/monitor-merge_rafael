using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.DTO
{
    public class ParametroDTO
    {
        public string NomePrograma { get; set; }
        public string Tipo { get; set; }
        public string NomeTipoParametro { get; set; }
        public string Vigencia { get; set; }
        public string FlagAtivo { get; set; }
        public string QtdeMeses { get; set; }
        public string Autonomia { get; set; }
        public string DtInicial { get; set; }
        public string DtFinal { get; set; }
        public int IdProgramaMonitor { get; set; }
        public int IdParametro { get; set; }
        public int IdRegraMotor { get; set; }
        public string VlParametro { get; set; }
        public string Apresentacao { get; set; }
        public string ConsumoMensal { get; set; }
        public string FormulaCalculo { get; set; }

    }
}
