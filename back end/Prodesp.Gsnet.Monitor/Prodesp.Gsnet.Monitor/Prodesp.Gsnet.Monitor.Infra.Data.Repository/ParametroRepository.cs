using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Infra.Data.EF.Implementacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Data.Repositorios;
using Prodesp.Gsnet.Monitor.Domain;
using Prodesp.Gsnet.Monitor.Domain.DTO;

namespace Prodesp.Gsnet.Monitor.Infra.Data.Repository
{
    public class ParametroRepository : EFRepository<Parametro>, IParametroRepository
    {
        public ParametroRepository(IUnitOfWork uow) : base(uow)
        {

        }

        public List<DadosViewDetalheConsumo> retDadosViewDetalheConsumo()
        {
            //var IdRegraMotor = 123;

            var detalhes = new DadosViewDetalheConsumo();
            var query = (from par in this._contexto.Parametros
                         join parvalor in this._contexto.ParametroValors on par.Id equals parvalor.IdParametro
                         //where parvalor.IdRegraMotor == IdRegraMotor
                         select new DadosViewDetalheConsumo
                         {
                             Id = par.Id,
                             IdRegraMotor = parvalor.IdRegraMotor,
                             NomeParametro = par.DsParametro,
                             ValorParametro = parvalor.VlParametro

                         }).AsQueryable();
            return query.ToList();
        }


       



    }
}
