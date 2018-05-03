using Castle.DynamicLinqQueryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.Requests
{
    public class SearchRequest
    {
        public FilterRule Filter { get; set; }
        public string OrderBy { get; set; }
        public int PageNumber { get; set; }
        public int RecordsPerPage { get; set; }
        public string SortDirection { get; set; }
    }
}
