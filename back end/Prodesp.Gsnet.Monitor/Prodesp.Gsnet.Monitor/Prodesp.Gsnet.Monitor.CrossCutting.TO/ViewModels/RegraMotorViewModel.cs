using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;


namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels
{
    public class RegraMotorViewModel
    {
        public int IdRegraMotor { get; set; }
        public int IdProgramaMotor { get; set; }
        public int TpParametro { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime DataFimVigencia { get; set; }
        public string FlagAtivo { get; set; }
        public string FlStatus { get; set; }
        public string NomePrograma { get; set; }
        public string NomeTipoParametro { get; set; }
        public string Vigencia
        {
            get
            {
                var retorno = "";
                retorno = this.DataInicioVigencia.ToShortDateString();
                if (this.DataFimVigencia.Year == 1)
                {
                    return retorno+= " à atual";
                }
                else
                {
                    retorno += " até ";
                    retorno += DataFimVigencia.ToShortDateString() ;
                    return retorno;
                }
                
            }

        }
    }
}
