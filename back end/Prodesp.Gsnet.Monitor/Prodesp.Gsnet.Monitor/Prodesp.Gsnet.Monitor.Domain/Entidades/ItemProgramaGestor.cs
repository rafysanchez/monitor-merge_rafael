using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using System;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Keys;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades
{
    public class ItemProgramaGestor : IVigencia, IIntEntityKey, ISelfValidation
    {
        public int Id { get; set; }
        public int IdItemPrograma { get; set; }
        public int IdGestor { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime? DataFimVigencia { get; set; }
        public string FlagAtivo { get; set; }
        public ValidationResult ValidationResult
        {
            get;
        }
        public bool IsValid
        {
            get;
        }
    }
}