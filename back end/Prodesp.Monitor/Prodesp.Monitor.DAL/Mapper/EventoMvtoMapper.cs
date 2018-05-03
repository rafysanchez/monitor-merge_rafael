using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.DAL.DataBase.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.EventoMvto;
using Prodesp.Monitor.TO.Response.EventoMvto;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class EventoMvtoMapper : ClassMapping<Model.EventoMvto>
    {
        public EventoMvtoMapper()
        {
            Schema(HelperConstantsExtension.GsnetEstoqueSchema);
            Table("MON_EVENTO_MVTO");
            ComposedId(m=> {
                    m.Property(p => p.IdEvento, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_EVENTO");}); });
                    m.Property(p => p.IdMvto, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_MVTO");}); });
            });


            Property(p => p.DtInclusao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_INCLUSAO" );}); map.NotNullable(true);});
            Property(p => p.DtAlteracao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_ALTERACAO" );}); map.NotNullable(true);});
            Property(p => p.QtSaldo, map => { map.Column(c => { c.SqlType("NUMBER");c.Name("QT_SALDO" );}); map.NotNullable(true);});
            Property(p => p.NrAutonomiaCritica, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_AUTONOMIA_CRITICA");}); map.NotNullable(false);});
            Property(p => p.NrAutonomia, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_AUTONOMIA");}); map.NotNullable(false);});
            Property(p => p.FlEstoqueCritico, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("FL_ESTOQUE_CRITICO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.FlEstoqueCritico, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("FL_ESTOQUE_CRITICO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.FlEstoqueZerado, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("FL_ESTOQUE_ZERADO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.FlEstoqueZerado, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("FL_ESTOQUE_ZERADO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.QtConsumoMes, map => { map.Column(c => { c.SqlType("NUMBER");c.Name("QT_CONSUMO_MES" );}); map.NotNullable(true);});
            Property(p => p.QtConsumoMedio, map => { map.Column(c => { c.SqlType("NUMBER");c.Name("QT_CONSUMO_MEDIO" );}); map.NotNullable(true);});
            Property(p => p.DtUltSaida, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_ULT_SAIDA");}); map.NotNullable(false);});
            Property(p => p.QtUltSaida, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("QT_ULT_SAIDA");}); map.NotNullable(false);});
            Property(p => p.DtUltEntrada, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_ULT_ENTRADA");}); map.NotNullable(false);});
            Property(p => p.QtUltEntrada, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("QT_ULT_ENTRADA");}); map.NotNullable(false);});
            Property(p => p.NrDocumentoUltEntrada, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_DOCUMENTO_ULT_ENTRADA");}); map.NotNullable(false);});
            Property(p => p.SrDocumentoUltEntrada, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("SR_DOCUMENTO_ULT_ENTRADA");}); map.Length(1); map.NotNullable(false);});
            Property(p => p.SrDocumentoUltEntrada, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("SR_DOCUMENTO_ULT_ENTRADA");}); map.Length(1); map.NotNullable(false);});
            Property(p => p.NrDocumentoUltSaida, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_DOCUMENTO_ULT_SAIDA");}); map.NotNullable(false);});
            Property(p => p.SrDocumentoUltSaida, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("SR_DOCUMENTO_ULT_SAIDA");}); map.Length(1); map.NotNullable(false);});
            Property(p => p.SrDocumentoUltSaida, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("SR_DOCUMENTO_ULT_SAIDA");}); map.Length(1); map.NotNullable(false);});
            Property(p => p.DtUltSaidaFatura, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_ULT_SAIDA_FATURA");}); map.NotNullable(false);});
            Property(p => p.QtUltSaidaFatura, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("QT_ULT_SAIDA_FATURA");}); map.NotNullable(false);});
            Property(p => p.NrDocumentoUltSaidaFatura, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_DOCUMENTO_ULT_SAIDA_FATURA");}); map.NotNullable(false);});
            Property(p => p.SrDocumentoUltSaidaFatura, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("SR_DOCUMENTO_ULT_SAIDA_FATURA");}); map.Length(1); map.NotNullable(false);});
            Property(p => p.SrDocumentoUltSaidaFatura, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("SR_DOCUMENTO_ULT_SAIDA_FATURA");}); map.Length(1); map.NotNullable(false);});

            ManyToOne(p => p.Evento, m => { m.Column("ID_EVENTO"); m.Insert(false); m.Update(false); });
        }
    }

    public static class EventoMvtoHelperMapper
    {
        public static EventoMvtoListResponseData ToResponseData(this Model.EventoMvto model)
        {
            return new EventoMvtoListResponseData
            {
                IdEvento = model.IdEvento,
                IdMvto = model.IdMvto,
                DtInclusao = model.DtInclusao,
                DtAlteracao = model.DtAlteracao,
                QtSaldo = model.QtSaldo,
                NrAutonomiaCritica = model.NrAutonomiaCritica,
                NrAutonomia = model.NrAutonomia,
                FlEstoqueCritico = model.FlEstoqueCritico,
                FlEstoqueZerado = model.FlEstoqueZerado,
                QtConsumoMes = model.QtConsumoMes,
                QtConsumoMedio = model.QtConsumoMedio,
                DtUltSaida = model.DtUltSaida,
                QtUltSaida = model.QtUltSaida,
                DtUltEntrada = model.DtUltEntrada,
                QtUltEntrada = model.QtUltEntrada,
                NrDocumentoUltEntrada = model.NrDocumentoUltEntrada,
                SrDocumentoUltEntrada = model.SrDocumentoUltEntrada,
                NrDocumentoUltSaida = model.NrDocumentoUltSaida,
                SrDocumentoUltSaida = model.SrDocumentoUltSaida,
                DtUltSaidaFatura = model.DtUltSaidaFatura,
                QtUltSaidaFatura = model.QtUltSaidaFatura,
                NrDocumentoUltSaidaFatura = model.NrDocumentoUltSaidaFatura,
                SrDocumentoUltSaidaFatura = model.SrDocumentoUltSaidaFatura,
                
            };
        }

        public static EventoMvtoListResponse ToListResponse(this DataSet<Model.EventoMvto> model)
        {
            return new EventoMvtoListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.EventoMvto FromRequestData(this EventoMvtoSingleRequestData request)
        {
            return new Model.EventoMvto
            {
                IdEvento = request.IdEvento,
                IdMvto = request.IdMvto,
                DtInclusao = request.DtInclusao,
                DtAlteracao = request.DtAlteracao,
                QtSaldo = request.QtSaldo,
                NrAutonomiaCritica = request.NrAutonomiaCritica,
                NrAutonomia = request.NrAutonomia,
                FlEstoqueCritico = request.FlEstoqueCritico,
                FlEstoqueZerado = request.FlEstoqueZerado,
                QtConsumoMes = request.QtConsumoMes,
                QtConsumoMedio = request.QtConsumoMedio,
                DtUltSaida = request.DtUltSaida,
                QtUltSaida = request.QtUltSaida,
                DtUltEntrada = request.DtUltEntrada,
                QtUltEntrada = request.QtUltEntrada,
                NrDocumentoUltEntrada = request.NrDocumentoUltEntrada,
                SrDocumentoUltEntrada = request.SrDocumentoUltEntrada,
                NrDocumentoUltSaida = request.NrDocumentoUltSaida,
                SrDocumentoUltSaida = request.SrDocumentoUltSaida,
                DtUltSaidaFatura = request.DtUltSaidaFatura,
                QtUltSaidaFatura = request.QtUltSaidaFatura,
                NrDocumentoUltSaidaFatura = request.NrDocumentoUltSaidaFatura,
                SrDocumentoUltSaidaFatura = request.SrDocumentoUltSaidaFatura,
                
            };
        }
    }
}
