using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.DAL.DataBase.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.EmpenhoMvto;
using Prodesp.Monitor.TO.Response.EmpenhoMvto;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class EmpenhoMvtoMapper : ClassMapping<Model.EmpenhoMvto>
    {
        public EmpenhoMvtoMapper()
        {
            Schema(HelperConstantsExtension.GsnetEstoqueSchema);
            Table("MON_EMPENHO_MVTO");
            ComposedId(m=> {
                    m.Property(p => p.NrEmpenho, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_EMPENHO");}); });
                    m.Property(p => p.NrAnoEmpenho, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_ANO_EMPENHO");}); });
                    m.Property(p => p.IdItem, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_ITEM");}); });
                    m.Property(p => p.IdGestor, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_GESTOR");}); });
                    m.Property(p => p.IdLocal, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_LOCAL");}); });
                    m.Property(p => p.IdMvto, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_MVTO");}); });
            });


            Property(p => p.DtInclusao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_INCLUSAO" );}); map.NotNullable(true);});
            Property(p => p.DtAlteracao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_ALTERACAO" );}); map.NotNullable(true);});
            Property(p => p.QtUnitEmpenho, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("QT_UNIT_EMPENHO");}); map.NotNullable(false);});
            Property(p => p.QtUnitAdiantada, map => { map.Column(c => { c.SqlType("NUMBER");c.Name("QT_UNIT_ADIANTADA" );}); map.NotNullable(true);});
            Property(p => p.StSituacao, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_SITUACAO");}); map.Length(1); map.NotNullable(false);});
            Property(p => p.StSituacao, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_SITUACAO");}); map.Length(1); map.NotNullable(false);});

            ManyToOne(p => p.Empenho , m => { m.Column("NR_EMPENHO "); m.Insert(false); m.Update(false); });
        }
    }

    public static class EmpenhoMvtoHelperMapper
    {
        public static EmpenhoMvtoListResponseData ToResponseData(this Model.EmpenhoMvto model)
        {
            return new EmpenhoMvtoListResponseData
            {
                NrEmpenho = model.NrEmpenho,
                NrAnoEmpenho = model.NrAnoEmpenho,
                IdItem = model.IdItem,
                IdGestor = model.IdGestor,
                IdLocal = model.IdLocal,
                IdMvto = model.IdMvto,
                DtInclusao = model.DtInclusao,
                DtAlteracao = model.DtAlteracao,
                QtUnitEmpenho = model.QtUnitEmpenho,
                QtUnitAdiantada = model.QtUnitAdiantada,
                StSituacao = model.StSituacao,
                
            };
        }

        public static EmpenhoMvtoListResponse ToListResponse(this DataSet<Model.EmpenhoMvto> model)
        {
            return new EmpenhoMvtoListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.EmpenhoMvto FromRequestData(this EmpenhoMvtoSingleRequestData request)
        {
            return new Model.EmpenhoMvto
            {
                NrEmpenho = request.NrEmpenho,
                NrAnoEmpenho = request.NrAnoEmpenho,
                IdItem = request.IdItem,
                IdGestor = request.IdGestor,
                IdLocal = request.IdLocal,
                IdMvto = request.IdMvto,
                DtInclusao = DateHelper.Now,
                DtAlteracao = DateHelper.Now,
                QtUnitEmpenho = request.QtUnitEmpenho,
                QtUnitAdiantada = request.QtUnitAdiantada,
                StSituacao = request.StSituacao,
                
            };
        }
    }
}
