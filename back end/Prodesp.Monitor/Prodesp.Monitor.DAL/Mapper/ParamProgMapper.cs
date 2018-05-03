using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.ParamProg;
using Prodesp.Monitor.TO.Response.ParamProg;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class ParamProgMapper : ClassMapping<Model.ParamProg>
    {
        public ParamProgMapper()
        {
            Schema(HelperConstantsExtension.GsnetEstoqueSchema);
            Table("MON_PARAM_PROG");
            ComposedId(m=> {
                    m.Property(p => p.IdPrograma, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_PROGRAMA");}); });
                    m.Property(p => p.NmParamProg, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("NM_PARAM_PROG");}); map.Length(40);});
            });


            Property(p => p.VlParamProg, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("VL_PARAM_PROG");}); map.Length(20); map.NotNullable(false);});
            Property(p => p.DtInclusao, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_INCLUSAO");}); map.NotNullable(false);});
            Property(p => p.DtAlteracao, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_ALTERACAO");}); map.NotNullable(false);});
            Property(p => p.StRegistro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_REGISTRO");}); map.Length(1); map.NotNullable(false);});
            Property(p => p.StRegistro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_REGISTRO");}); map.Length(1); map.NotNullable(false);});
            Property(p => p.UserId, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("USER_ID");}); map.Length(255); map.NotNullable(false);});

            ManyToOne(p => p.Programa, m => { m.Column("ID_PROGRAMA"); m.Insert(false); m.Update(false); });
        }
    }

    public static class ParamProgHelperMapper
    {
        public static ParamProgListResponseData ToResponseData(this Model.ParamProg model)
        {
            return new ParamProgListResponseData
            {
                IdPrograma = model.IdPrograma,
                NmParamProg = model.NmParamProg,
                VlParamProg = model.VlParamProg,
                DtInclusao = model.DtInclusao,
                DtAlteracao = model.DtAlteracao,
                StRegistro = model.StRegistro,
                UserId = model.UserId,
                
            };
        }

        public static ParamProgListResponse ToListResponse(this DataSet<Model.ParamProg> model)
        {
            return new ParamProgListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.ParamProg FromRequestData(this ParamProgSingleRequestData request)
        {
            return new Model.ParamProg
            {
                IdPrograma = request.IdPrograma,
                NmParamProg = request.NmParamProg,
                VlParamProg = request.VlParamProg,
                DtInclusao = request.DtInclusao,
                DtAlteracao = request.DtAlteracao,
                StRegistro = request.StRegistro,
                UserId = request.UserId,
                
            };
        }
    }
}
