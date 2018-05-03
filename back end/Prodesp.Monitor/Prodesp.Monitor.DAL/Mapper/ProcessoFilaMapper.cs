using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.DAL.DataBase.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.ProcessoFila;
using Prodesp.Monitor.TO.Response.ProcessoFila;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class ProcessoFilaMapper : ClassMapping<Model.ProcessoFila>
    {
        public ProcessoFilaMapper()
        {
            Schema(HelperConstantsExtension.GsnetEstoqueSchema);
            Table("MON_PROCESSO_FILA");
            ComposedId(m=> {
                    m.Property(p => p.IdGestor, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_GESTOR");}); });
                    m.Property(p => p.IdLocal, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_LOCAL");}); });
            });


            Property(p => p.CdAcao, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("CD_ACAO");}); map.Length(15); map.NotNullable(true);});
            Property(p => p.UserId, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("USER_ID");}); map.Length(255); map.NotNullable(false);});

        }
    }

    public static class ProcessoFilaHelperMapper
    {
        public static ProcessoFilaListResponseData ToResponseData(this Model.ProcessoFila model)
        {
            return new ProcessoFilaListResponseData
            {
                IdGestor = model.IdGestor,
                IdLocal = model.IdLocal,
                CdAcao = model.CdAcao,
                UserId = model.UserId,
                
            };
        }

        public static ProcessoFilaListResponse ToListResponse(this DataSet<Model.ProcessoFila> model)
        {
            return new ProcessoFilaListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.ProcessoFila FromRequestData(this ProcessoFilaSingleRequestData request)
        {
            return new Model.ProcessoFila
            {
                IdGestor = request.IdGestor,
                IdLocal = request.IdLocal,
                CdAcao = request.CdAcao,
                UserId = request.UserId,
                
            };
        }
    }
}
