using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.DAL.DataBase.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.MensagemWs;
using Prodesp.Monitor.TO.Response.MensagemWs;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class MensagemWsMapper : ClassMapping<Model.MensagemWs>
    {
        public MensagemWsMapper()
        {
            Schema(HelperConstantsExtension.GsnetEstoqueSchema);
            Table("MON_MENSAGEM_WS");
            ComposedId(m=> {
                    m.Property(p => p.IdMensagem, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_MENSAGEM");}); });
            });


            Property(p => p.DsMensagem, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("DS_MENSAGEM");}); map.Length(100); map.NotNullable(true);});
            Property(p => p.StRegistro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_REGISTRO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.StRegistro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_REGISTRO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.DtInclusao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_INCLUSAO" );}); map.NotNullable(true);});
            Property(p => p.DtAlteracao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_ALTERACAO" );}); map.NotNullable(true);});

        }
    }

    public static class MensagemWsHelperMapper
    {
        public static MensagemWsListResponseData ToResponseData(this Model.MensagemWs model)
        {
            return new MensagemWsListResponseData
            {
                IdMensagem = model.IdMensagem,
                DsMensagem = model.DsMensagem,
                StRegistro = model.StRegistro,
                DtInclusao = model.DtInclusao,
                DtAlteracao = model.DtAlteracao,
                
            };
        }

        public static MensagemWsListResponse ToListResponse(this DataSet<Model.MensagemWs> model)
        {
            return new MensagemWsListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.MensagemWs FromRequestData(this MensagemWsSingleRequestData request)
        {
            return new Model.MensagemWs
            {
                IdMensagem = request.IdMensagem,
                DsMensagem = request.DsMensagem,
                StRegistro = request.StRegistro,
                DtInclusao = request.DtInclusao,
                DtAlteracao = request.DtAlteracao,
                
            };
        }
    }
}
