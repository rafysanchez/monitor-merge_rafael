using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodesp.Gsnet.Monitor.Presentation.WebApi.Models
{
    public class MonitorResponse
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public object Dados { get; set; }
    }
}