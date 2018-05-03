using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades
{
    public class ItemMonitoramento : ISelfValidation
    {
        public long Id { get; set; }
        public long IdMonitoramento { get; set; }
        public int IdItemProgramaGestor { get; set; }
        //public int IdUsuario { get; set; }
        public long? QuantidadeSaldoDisponivel { get; set; }
        public decimal? QuantidadeDiasAutonomia { get; set; }
        public long? QuantidadeUltimaFatura { get; set; }
        public DateTime? DataUltimaFatura { get; set; }
        public long? QuantidadeUltimoEmpenho { get; set; }
        public DateTime? DataUltimoEmpenho { get; set; }
        public long? QuantidadeUltimoConsumo { get; set; }
        public DateTime? DataUltimoConsumo { get; set; }
        public short? TipoConsumo { get; set; }
        public long? QuantidadeConsumo { get; set; }
        public short? TipoRegra { get; set; }
        public bool IsValid
        {
            get
            {
                return true;
            }
        }

        public Monitoramento Monitoramento { get; set; }
        public Usuario Usuario { get; set; }
        public ItemProgramaGestor ItemProgramaGestor { get; set; }
        public ValidationResult ValidationResult
        {
            get
            {
                return new ValidationResult();
            }
        }
    }
}
