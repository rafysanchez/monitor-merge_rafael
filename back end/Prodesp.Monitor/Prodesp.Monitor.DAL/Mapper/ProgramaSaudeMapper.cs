using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.DAL.DataBase.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.ProgramaSaude;
using Prodesp.Monitor.TO.Response.ProgramaSaude;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class ProgramaSaudeMapper : ClassMapping<Model.ProgramaSaude>
    {
        public ProgramaSaudeMapper()
        {
            Schema(HelperConstantsExtension.GsnetEstoqueSchema);
            Table("MON_PROGRAMA_SAUDE");
            ComposedId(m=> {
                    m.Property(p => p.IdPrograma, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_PROGRAMA");}); });
            });


            Property(p => p.NmPrograma, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("NM_PROGRAMA");}); map.Length(40); map.NotNullable(true);});
            Property(p => p.DtInclusao, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_INCLUSAO");}); map.NotNullable(false);});
            Property(p => p.DtAlteracao, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_ALTERACAO");}); map.NotNullable(false);});
            Property(p => p.StRegistro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_REGISTRO");}); map.Length(1); map.NotNullable(false);});
            Property(p => p.StRegistro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_REGISTRO");}); map.Length(1); map.NotNullable(false);});
            Property(p => p.UserId, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("USER_ID");}); map.Length(255); map.NotNullable(false);});

        }
    }

    public static class ProgramaSaudeHelperMapper
    {
        public static ProgramaSaudeListResponseData ToResponseData(this Model.ProgramaSaude model)
        {
            return new ProgramaSaudeListResponseData
            {
                IdPrograma = model.IdPrograma,
                NmPrograma = model.NmPrograma,
                DtInclusao = model.DtInclusao,
                DtAlteracao = model.DtAlteracao,
                StRegistro = model.StRegistro,
                UserId = model.UserId,
                
            };
        }

        public static ProgramaSaudeListResponse ToListResponse(this DataSet<Model.ProgramaSaude> model)
        {
            return new ProgramaSaudeListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.ProgramaSaude FromRequestData(this ProgramaSaudeSingleRequestData request)
        {
            return new Model.ProgramaSaude
            {
                IdPrograma = request.IdPrograma,
                NmPrograma = request.NmPrograma,
                DtInclusao = request.DtInclusao,
                DtAlteracao = request.DtAlteracao,
                StRegistro = request.StRegistro,
                UserId = request.UserId,
                
            };
        }
    }
}
