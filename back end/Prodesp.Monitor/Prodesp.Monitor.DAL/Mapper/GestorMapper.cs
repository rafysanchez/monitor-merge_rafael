using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.DAL.DataBase.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.Gestor;
using Prodesp.Monitor.TO.Response.Gestor;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class GestorMapper : ClassMapping<Model.Gestor>
    {
        public GestorMapper()
        {
            Schema(HelperConstantsExtension.GsnetEstoqueSchema);
            Table("MON_GESTOR");
            ComposedId(m=> {
                    m.Property(p => p.IdGestor, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_GESTOR");}); });
                    m.Property(p => p.IdLocal, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_LOCAL");}); });
            });


            Property(p => p.DtInclusao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_INCLUSAO" );}); map.NotNullable(true);});
            Property(p => p.IdInstitucional, map => { map.Column(c => { c.SqlType("NUMBER");c.Name("ID_INSTITUCIONAL" );}); map.NotNullable(true);});
            Property(p => p.IdGestorPai, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_GESTOR_PAI");}); map.NotNullable(false);});
            Property(p => p.IdLocalPai, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_LOCAL_PAI");}); map.NotNullable(false);});
            Property(p => p.NrAnoRef, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_ANO_REF");}); map.NotNullable(false);});
            Property(p => p.NrMesRef, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_MES_REF");}); map.NotNullable(false);});
            Property(p => p.NmInstitucional, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("NM_INSTITUCIONAL");}); map.Length(60); map.NotNullable(false);});
            Property(p => p.IdInstitucionalPai, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_INSTITUCIONAL_PAI");}); map.NotNullable(false);});
            Property(p => p.StRegistro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_REGISTRO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.DtAlteracao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_ALTERACAO" );}); map.NotNullable(true);});
            Property(p => p.NmLocal, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("NM_LOCAL");}); map.Length(60); map.NotNullable(false);});
            Property(p => p.DtProcessamento, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_PROCESSAMENTO");}); map.NotNullable(false);});

            ManyToOne(p => p.GestorPai , m => { m.Column("ID_GESTOR_PAI "); m.Insert(false); m.Update(false); });
        }
    }

    public static class GestorHelperMapper
    {
        public static GestorListResponseData ToResponseData(this Model.Gestor model)
        {
            return new GestorListResponseData
            {
                DtInclusao = model.DtInclusao,
                IdGestor = model.IdGestor,
                IdLocal = model.IdLocal,
                IdInstitucional = model.IdInstitucional,
                IdGestorPai = model.IdGestorPai,
                IdLocalPai = model.IdLocalPai,
                NrAnoRef = model.NrAnoRef,
                NrMesRef = model.NrMesRef,
                NmInstitucional = model.NmInstitucional,
                IdInstitucionalPai = model.IdInstitucionalPai,
                StRegistro = model.StRegistro,
                DtAlteracao = model.DtAlteracao,
                NmLocal = model.NmLocal,
                DtProcessamento = model.DtProcessamento,
                
            };
        }

        public static GestorListResponse ToListResponse(this DataSet<Model.Gestor> model)
        {
            return new GestorListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.Gestor FromRequestData(this GestorSingleRequestData request)
        {
            return new Model.Gestor
            {
                DtInclusao = DateHelper.Now,
                IdGestor = request.IdGestor,
                IdLocal = request.IdLocal,
                IdInstitucional = request.IdInstitucional,
                IdGestorPai = request.IdGestorPai,
                IdLocalPai = request.IdLocalPai,
                NrAnoRef = request.NrAnoRef,
                NrMesRef = request.NrMesRef,
                NmInstitucional = request.NmInstitucional,
                IdInstitucionalPai = request.IdInstitucionalPai,
                StRegistro = request.StRegistro,
                DtAlteracao = DateHelper.Now,
                NmLocal = request.NmLocal,
                DtProcessamento = request.DtProcessamento,
                
            };
        }
    }
}
