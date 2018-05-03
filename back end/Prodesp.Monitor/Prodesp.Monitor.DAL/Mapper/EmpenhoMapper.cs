using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.DAL.DataBase.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.Empenho;
using Prodesp.Monitor.TO.Response.Empenho;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class EmpenhoMapper : ClassMapping<Model.Empenho>
    {
        public EmpenhoMapper()
        {
            Schema(HelperConstantsExtension.GsnetEstoqueSchema);
            Table("MON_EMPENHO");
            ComposedId(m=> {
                    m.Property(p => p.NrEmpenho, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_EMPENHO");}); });
                    m.Property(p => p.NrAnoEmpenho, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_ANO_EMPENHO");}); });
                    m.Property(p => p.IdItem, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_ITEM");}); });
                    m.Property(p => p.IdGestor, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_GESTOR");}); });
                    m.Property(p => p.IdLocal, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_LOCAL");}); });
            });


            Property(p => p.QtUnitEmpenho, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("QT_UNIT_EMPENHO");}); map.NotNullable(false);});
            Property(p => p.QtUnitAdiantada, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("QT_UNIT_ADIANTADA");}); map.NotNullable(false);});
            Property(p => p.DtInclusao, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_INCLUSAO");}); map.NotNullable(false);});
            Property(p => p.DtAlteracao, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_ALTERACAO");}); map.NotNullable(false);});
            Property(p => p.StSituacao, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_SITUACAO");}); map.Length(1); map.NotNullable(false);});
            Property(p => p.StSituacao, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_SITUACAO");}); map.Length(1); map.NotNullable(false);});

            ManyToOne(p => p.Item, m => { m.Column("ID_ITEM"); m.Insert(false); m.Update(false); });
            ManyToOne(p => p.Gestor , m => { m.Column("ID_GESTOR "); m.Insert(false); m.Update(false); });
        }
    }

    public static class EmpenhoHelperMapper
    {
        public static EmpenhoListResponseData ToResponseData(this Model.Empenho model)
        {
            return new EmpenhoListResponseData
            {
                NrEmpenho = model.NrEmpenho,
                NrAnoEmpenho = model.NrAnoEmpenho,
                IdItem = model.IdItem,
                IdGestor = model.IdGestor,
                IdLocal = model.IdLocal,
                QtUnitEmpenho = model.QtUnitEmpenho,
                QtUnitAdiantada = model.QtUnitAdiantada,
                DtInclusao = model.DtInclusao,
                DtAlteracao = model.DtAlteracao,
                StSituacao = model.StSituacao,
                
            };
        }

        public static EmpenhoListResponse ToListResponse(this DataSet<Model.Empenho> model)
        {
            return new EmpenhoListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.Empenho FromRequestData(this EmpenhoSingleRequestData request)
        {
            return new Model.Empenho
            {
                NrEmpenho = request.NrEmpenho,
                NrAnoEmpenho = request.NrAnoEmpenho,
                IdItem = request.IdItem,
                IdGestor = request.IdGestor,
                IdLocal = request.IdLocal,
                QtUnitEmpenho = request.QtUnitEmpenho,
                QtUnitAdiantada = request.QtUnitAdiantada,
                DtInclusao = DateHelper.Now,
                DtAlteracao = DateHelper.Now,
                StSituacao = request.StSituacao,
                
            };
        }
    }
}
