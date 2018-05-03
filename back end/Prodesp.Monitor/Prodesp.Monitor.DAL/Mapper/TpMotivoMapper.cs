using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.DAL.DataBase.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.TpMotivo;
using Prodesp.Monitor.TO.Response.TpMotivo;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class TpMotivoMapper : ClassMapping<Model.TpMotivo>
    {
        public TpMotivoMapper()
        {
            Schema(HelperConstantsExtension.GsnetEstoqueSchema);
            Table("MON_TP_MOTIVO");
            ComposedId(m=> {
                    m.Property(p => p.IdMotivo, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_MOTIVO");}); });
            });


            Property(p => p.DsMotivo, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("DS_MOTIVO");}); map.Length(100); map.NotNullable(false);});
            Property(p => p.StRegistro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_REGISTRO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.StRegistro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_REGISTRO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.DtInclusao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_INCLUSAO" );}); map.NotNullable(true);});
            Property(p => p.DtAlteracao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_ALTERACAO" );}); map.NotNullable(true);});
            Property(p => p.UserId, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("USER_ID");}); map.Length(255); map.NotNullable(false);});

        }
    }

    public static class TpMotivoHelperMapper
    {
        public static TpMotivoListResponseData ToResponseData(this Model.TpMotivo model)
        {
            return new TpMotivoListResponseData
            {
                IdMotivo = model.IdMotivo,
                DsMotivo = model.DsMotivo,
                StRegistro = model.StRegistro,
                DtInclusao = model.DtInclusao,
                DtAlteracao = model.DtAlteracao,
                UserId = model.UserId,
                
            };
        }

        public static TpMotivoListResponse ToListResponse(this DataSet<Model.TpMotivo> model)
        {
            return new TpMotivoListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.TpMotivo FromRequestData(this TpMotivoSingleRequestData request)
        {
            return new Model.TpMotivo
            {
                IdMotivo = request.IdMotivo,
                DsMotivo = request.DsMotivo,
                StRegistro = request.StRegistro,
                UserId = request.UserId,
                DtAlteracao= DateHelper.Now,
                DtInclusao= DateHelper.Now
            };
        }
    }
}
