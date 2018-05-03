using Castle.DynamicLinqQueryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodesp.Gsnet.Monitor.Presentation.WebApi.Models
{
    public class MonitorRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortOrder { get; set; }
        public string SortColumn { get; set; }

        public FilterRule Filtros { get; set; }
    }
}