using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades
{
    public class SearchResult<TEntity>
    {
        public IEnumerable<TEntity> Itens { get; set; }
        public int RecordsPerPage { get; set; }
        public int PageNumber { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }
}
