using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.DAL.DataBase.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.Item;
using Prodesp.Monitor.TO.Response.Item;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class ItemMapper : ClassMapping<Model.Item>
    {
        public ItemMapper()
        {
            Schema(HelperConstantsExtension.GsnetEstoqueSchema);
            Table("MON_ITEM");
            ComposedId(m=> {
                    m.Property(p => p.IdItem, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_ITEM");}); });
            });


            Property(p => p.NmUnidMedida, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("NM_UNID_MEDIDA");}); map.Length(60); map.NotNullable(true);});
            Property(p => p.NmItem, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("NM_ITEM");}); map.Length(700); map.NotNullable(true);});
            Property(p => p.NmItemFonetico, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("NM_ITEM_FONETICO");}); map.Length(70); map.NotNullable(false);});
            Property(p => p.IdProgramaSaude, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_PROGRAMA_SAUDE");}); map.NotNullable(false);});
            Property(p => p.NmProgramaSaude, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("NM_PROGRAMA_SAUDE");}); map.Length(25); map.NotNullable(false);});
            Property(p => p.StRegistro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_REGISTRO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.StRegistro, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("ST_REGISTRO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.DtInclusao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_INCLUSAO" );}); map.NotNullable(true);});
            Property(p => p.DtAlteracao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_ALTERACAO" );}); map.NotNullable(true);});
            Property(p => p.UserId, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("USER_ID");}); map.Length(255); map.NotNullable(false);});
            Property(p => p.CdSiafisico, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("CD_SIAFISICO");}); map.Length(30); map.NotNullable(false);});
            Property(p => p.QtFatorConversao, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("QT_FATOR_CONVERSAO");}); map.NotNullable(false);});

        }
    }

    public static class ItemHelperMapper
    {
        public static ItemListResponseData ToResponseData(this Model.Item model)
        {
            return new ItemListResponseData
            {
                IdItem = model.IdItem,
                NmUnidMedida = model.NmUnidMedida,
                NmItem = model.NmItem,
                NmItemFonetico = model.NmItemFonetico,
                IdProgramaSaude = model.IdProgramaSaude,
                NmProgramaSaude = model.NmProgramaSaude,
                StRegistro = model.StRegistro,
                DtInclusao = model.DtInclusao,
                DtAlteracao = model.DtAlteracao,
                UserId = model.UserId,
                CdSiafisico = model.CdSiafisico,
                QtFatorConversao = model.QtFatorConversao,
                
            };
        }

        public static ItemListResponse ToListResponse(this DataSet<Model.Item> model)
        {
            return new ItemListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.Item FromRequestData(this ItemSingleRequestData request)
        {
            return new Model.Item
            {
                IdItem = request.IdItem,
                NmUnidMedida = request.NmUnidMedida,
                NmItem = request.NmItem,
                NmItemFonetico = request.NmItemFonetico,
                IdProgramaSaude = request.IdProgramaSaude,
                NmProgramaSaude = request.NmProgramaSaude,
                StRegistro = request.StRegistro,
                DtInclusao = DateHelper.Now,
                DtAlteracao = DateHelper.Now,
                UserId = request.UserId,
                CdSiafisico = request.CdSiafisico,
                QtFatorConversao = request.QtFatorConversao,
                
            };
        }
    }
}
