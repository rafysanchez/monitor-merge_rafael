using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.DTO
{
    public class ListDadosFarmaciaDTO
    {
        //public Grupo: string,
        //        public Codigo: string ,
        //        public Siafisico: string ,
        //        public NomeItem: string,
        //        public UniDistribuicao: string,
        //        public Status: string

        public int id_item_programa_saude { get; set; }
        public string Grupo { get; set; }
        public string Codigo { get; set; }
        public string Siafisico { get; set; }
        public string NomeItem { get; set; }
        public string UniDistribuicao { get; set; }
        public string Status { get; set; }


    }
}
