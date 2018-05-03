using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.DAL.DataBase.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.Processo;
using Prodesp.Monitor.TO.Response.Processo;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class ProcessoMapper : ClassMapping<Model.Processo>
    {
        public ProcessoMapper()
        {
            Schema(HelperConstantsExtension.GsnetEstoqueSchema);
            Table("MON_PROCESSO");
            ComposedId(m=> {
                    m.Property(p => p.Id, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID");}); });
            });


            Property(p => p.IdGestor, map => { map.Column(c => { c.SqlType("NUMBER");c.Name("ID_GESTOR" );}); map.NotNullable(true);});
            Property(p => p.IdLocal, map => { map.Column(c => { c.SqlType("NUMBER");c.Name("ID_LOCAL" );}); map.NotNullable(true);});
            Property(p => p.DtProcessamento, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_PROCESSAMENTO" );}); map.NotNullable(true);});
            Property(p => p.CdPrograma, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("CD_PROGRAMA");}); map.Length(30); map.NotNullable(true);});
            Property(p => p.IdProcesso, map => { map.Column(c => { c.SqlType("NUMBER");c.Name("ID_PROCESSO" );}); map.NotNullable(true);});
            Property(p => p.NmProcesso, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("NM_PROCESSO");}); map.Length(60); map.NotNullable(true);});
            Property(p => p.DsDescricao, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("DS_DESCRICAO");}); map.Length(1000); map.NotNullable(false);});
            Property(p => p.DtInclusao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_INCLUSAO" );}); map.NotNullable(true);});
            Property(p => p.DtAlteracao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_ALTERACAO" );}); map.NotNullable(true);});
            Property(p => p.FlErro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("FL_ERRO");}); map.Length(1); map.NotNullable(false);});
            Property(p => p.FlErro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("FL_ERRO");}); map.Length(1); map.NotNullable(false);});

        }
    }

    public static class ProcessoHelperMapper
    {
        public static ProcessoListResponseData ToResponseData(this Model.Processo model)
        {
            return new ProcessoListResponseData
            {
                Id = model.Id,
                IdGestor = model.IdGestor,
                IdLocal = model.IdLocal,
                DtProcessamento = model.DtProcessamento,
                CdPrograma = model.CdPrograma,
                IdProcesso = model.IdProcesso,
                NmProcesso = model.NmProcesso,
                DsDescricao = model.DsDescricao,
                DtInclusao = model.DtInclusao,
                DtAlteracao = model.DtAlteracao,
                FlErro = model.FlErro,
                
            };
        }

        public static ProcessoListResponse ToListResponse(this DataSet<Model.Processo> model)
        {
            return new ProcessoListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.Processo FromRequestData(this ProcessoSingleRequestData request)
        {
            return new Model.Processo
            {
                Id = request.Id,
                IdGestor = request.IdGestor,
                IdLocal = request.IdLocal,
                DtProcessamento = request.DtProcessamento,
                CdPrograma = request.CdPrograma,
                IdProcesso = request.IdProcesso,
                NmProcesso = request.NmProcesso,
                DsDescricao = request.DsDescricao,
                DtInclusao = DateHelper.Now,
                DtAlteracao = DateHelper.Now,
                FlErro = request.FlErro,
                
            };
        }
    }
}
