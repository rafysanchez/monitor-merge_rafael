using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.DAL.DataBase.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.TpAcao;
using Prodesp.Monitor.TO.Response.TpAcao;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class TpAcaoMapper : ClassMapping<Model.TpAcao>
    {
        public TpAcaoMapper()
        {
            Schema(HelperConstantsExtension.GsnetEstoqueSchema);
            Table("MON_TP_ACAO");
            ComposedId(m=> {
                    m.Property(p => p.IdTpAcao, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_TP_ACAO");}); });
            });


            Property(p => p.DsTpAcao, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("DS_TP_ACAO");}); map.Length(30); map.NotNullable(true);});
            Property(p => p.StRegistro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_REGISTRO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.StRegistro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_REGISTRO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.DtInclusao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_INCLUSAO" );}); map.NotNullable(true);});
            Property(p => p.DtAlteracao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_ALTERACAO" );}); map.NotNullable(true);});
            Property(p => p.UserId, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("USER_ID");}); map.Length(255); map.NotNullable(false);});

        }
    }

    public static class TpAcaoHelperMapper
    {
        public static TpAcaoListResponseData ToResponseData(this Model.TpAcao model)
        {
            return new TpAcaoListResponseData
            {
                IdTpAcao = model.IdTpAcao,
                DsTpAcao = model.DsTpAcao,
                StRegistro = model.StRegistro,
                DtInclusao = model.DtInclusao,
                DtAlteracao = model.DtAlteracao,
                UserId = model.UserId,
                
            };
        }

        public static TpAcaoListResponse ToListResponse(this DataSet<Model.TpAcao> model)
        {
            return new TpAcaoListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.TpAcao FromRequestData(this TpAcaoSingleRequestData request)
        {
            return new Model.TpAcao
            {
                IdTpAcao = request.IdTpAcao,
                DsTpAcao = request.DsTpAcao,
                StRegistro = request.StRegistro,
                UserId = request.UserId,
                DtAlteracao = DateHelper.Now,
                DtInclusao= DateHelper.Now
            };
        }
    }
}
