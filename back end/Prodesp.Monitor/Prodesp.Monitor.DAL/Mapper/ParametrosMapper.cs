using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.DAL.DataBase.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.Parametros;
using Prodesp.Monitor.TO.Response.Parametros;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class ParametrosMapper : ClassMapping<Model.Parametros>
    {
        public ParametrosMapper()
        {

            Schema(HelperConstantsExtension.GsnetEstoqueSchema);

            Table("MON_PARAMETROS");
            ComposedId(m=> {
                    m.Property(p => p.NmParam, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("NM_PARAM");}); map.Length(40);});
            });


            Property(p => p.DsParam, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("DS_PARAM");}); map.Length(255); map.NotNullable(true);});
            Property(p => p.VlParam, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("VL_PARAM");}); map.Length(20); map.NotNullable(false);});

        }
    }

    public static class ParametrosHelperMapper
    {
        public static ParametrosListResponseData ToResponseData(this Model.Parametros model)
        {
            return new ParametrosListResponseData
            {
                NmParam = model.NmParam,
                DsParam = model.DsParam,
                VlParam = model.VlParam,
                
            };
        }

        public static ParametrosListResponse ToListResponse(this DataSet<Model.Parametros> model)
        {
            return new ParametrosListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.Parametros FromRequestData(this ParametrosSingleRequestData request)
        {
            return new Model.Parametros
            {
                NmParam = request.NmParam,
                DsParam = request.DsParam,
                VlParam = request.VlParam,
                
            };
        }
    }
}
