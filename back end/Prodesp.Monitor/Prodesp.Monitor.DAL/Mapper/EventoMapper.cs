using NHibernate.Mapping.ByCode.Conformist;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.Framework.Extension.Helper;
using Prodesp.Monitor.TO.Request.Evento;
using Prodesp.Monitor.TO.Response.Evento;
using System.Linq;

namespace Prodesp.Monitor.DAL.Mapper
{
    public class EventoMapper : ClassMapping<Model.Evento>
    {
        public EventoMapper()
        {
            Schema(HelperConstantsExtension.GsnetEstoqueSchema);
            Table("MON_EVENTO");
            ComposedId(m=> {
                    m.Property(p => p.IdEvento, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_EVENTO");}); });
            });


            Property(p => p.IdGestor, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_GESTOR");}); map.NotNullable(false);});
            Property(p => p.IdLocal, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("ID_LOCAL");}); map.NotNullable(false);});
            Property(p => p.IdItem, map => { map.Column(c => { c.SqlType("NUMBER");c.Name("ID_ITEM" );}); map.NotNullable(true);});
            Property(p => p.DtInclusao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_INCLUSAO" );}); map.NotNullable(true);});
            Property(p => p.DtAlteracao, map => { map.Column(c => { c.SqlType("DATE");c.Name("DT_ALTERACAO" );}); map.NotNullable(true);});
            Property(p => p.QtSaldoInicial, map => { map.Column(c => { c.SqlType("NUMBER");c.Name("QT_SALDO_INICIAL" );}); map.NotNullable(true);});
            Property(p => p.NrAutonomiaInicial, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_AUTONOMIA_INICIAL");}); map.NotNullable(false);});
            Property(p => p.QtSaldo, map => { map.Column(c => { c.SqlType("NUMBER");c.Name("QT_SALDO" );}); map.NotNullable(true);});
            Property(p => p.QtConsumoMes, map => { map.Column(c => { c.SqlType("NUMBER");c.Name("QT_CONSUMO_MES" );}); map.NotNullable(true);});
            Property(p => p.QtConsumoMedio, map => { map.Column(c => { c.SqlType("NUMBER");c.Name("QT_CONSUMO_MEDIO" );}); map.NotNullable(true);});
            Property(p => p.NrAutonomia, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_AUTONOMIA");}); map.NotNullable(false);});
            Property(p => p.FlEstoqueCritico, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("FL_ESTOQUE_CRITICO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.FlEstoqueCritico, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("FL_ESTOQUE_CRITICO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.FlEstoqueZerado, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("FL_ESTOQUE_ZERADO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.FlEstoqueZerado, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("FL_ESTOQUE_ZERADO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.DtInicioEstoqueCritico, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_INICIO_ESTOQUE_CRITICO");}); map.NotNullable(false);});
            Property(p => p.DtFimEstoqueCritico, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_FIM_ESTOQUE_CRITICO");}); map.NotNullable(false);});
            Property(p => p.DtInicioEstoqueZerado, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_INICIO_ESTOQUE_ZERADO");}); map.NotNullable(false);});
            Property(p => p.DtFimEstoqueZerado, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_FIM_ESTOQUE_ZERADO");}); map.NotNullable(false);});
            Property(p => p.FlPublicacao, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("FL_PUBLICACAO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.FlPublicacao, map => { map.Column(c => { c.SqlType("CHAR"); c.Name("FL_PUBLICACAO");}); map.Length(1); map.NotNullable(true);});
            Property(p => p.DtPublicacao, map => { map.Column(c => { c.SqlType("DATE"); c.Name("DT_PUBLICACAO");}); map.NotNullable(false);});
            Property(p => p.NrAnoRef, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_ANO_REF");}); map.NotNullable(false);});
            Property(p => p.NrMesRef, map => { map.Column(c => { c.SqlType("NUMBER"); c.Name("NR_MES_REF");}); map.NotNullable(false);});
            Property(p => p.UserId, map => { map.Column(c => { c.SqlType("VARCHAR2"); c.Name("USER_ID");}); map.Length(255); map.NotNullable(false);});

            ManyToOne(p => p.Gestor , m => { m.Column("ID_GESTOR "); m.Insert(false); m.Update(false); });
            ManyToOne(p => p.Item, m => { m.Column("ID_ITEM"); m.Insert(false); m.Update(false); });
        }
    }

    public static class EventoHelperMapper
    {
        public static EventoListResponseData ToResponseData(this Model.Evento model)
        {
            return new EventoListResponseData
            {
                IdEvento = model.IdEvento,
                IdGestor = model.IdGestor,
                IdLocal = model.IdLocal,
                IdItem = model.IdItem,
                DtInclusao = model.DtInclusao,
                DtAlteracao = model.DtAlteracao,
                QtSaldoInicial = model.QtSaldoInicial,
                NrAutonomiaInicial = model.NrAutonomiaInicial,
                QtSaldo = model.QtSaldo,
                QtConsumoMes = model.QtConsumoMes,
                QtConsumoMedio = model.QtConsumoMedio,
                NrAutonomia = model.NrAutonomia,
                FlEstoqueCritico = model.FlEstoqueCritico,
                FlEstoqueZerado = model.FlEstoqueZerado,
                DtInicioEstoqueCritico = model.DtInicioEstoqueCritico,
                DtFimEstoqueCritico = model.DtFimEstoqueCritico,
                DtInicioEstoqueZerado = model.DtInicioEstoqueZerado,
                DtFimEstoqueZerado = model.DtFimEstoqueZerado,
                FlPublicacao = model.FlPublicacao,
                DtPublicacao = model.DtPublicacao,
                NrAnoRef = model.NrAnoRef,
                NrMesRef = model.NrMesRef,
                UserId = model.UserId,
                
            };
        }

        public static EventoListResponse ToListResponse(this DataSet<Model.Evento> model)
        {
            return new EventoListResponse
            {
                Data = model.Data.ToList().Select(s => s.ToResponseData()).ToList(),
                TotalPages = model.Pages,
                TotalRecords = model.Records
            };
        }

        public static Model.Evento FromRequestData(this EventoSingleRequestData request)
        {
            return new Model.Evento
            {
                IdEvento = request.IdEvento,
                IdGestor = request.IdGestor,
                IdLocal = request.IdLocal,
                IdItem = request.IdItem,
                DtInclusao = DateHelper.Now,
                DtAlteracao = DateHelper.Now,
                QtSaldoInicial = request.QtSaldoInicial,
                NrAutonomiaInicial = request.NrAutonomiaInicial,
                QtSaldo = request.QtSaldo,
                QtConsumoMes = request.QtConsumoMes,
                QtConsumoMedio = request.QtConsumoMedio,
                NrAutonomia = request.NrAutonomia,
                FlEstoqueCritico = request.FlEstoqueCritico,
                FlEstoqueZerado = request.FlEstoqueZerado,
                DtInicioEstoqueCritico = request.DtInicioEstoqueCritico,
                DtFimEstoqueCritico = request.DtFimEstoqueCritico,
                DtInicioEstoqueZerado = request.DtInicioEstoqueZerado,
                DtFimEstoqueZerado = request.DtFimEstoqueZerado,
                FlPublicacao = request.FlPublicacao,
                DtPublicacao = request.DtPublicacao,
                NrAnoRef = request.NrAnoRef,
                NrMesRef = request.NrMesRef,
                UserId = request.UserId,
                
            };
        }
    }
}
