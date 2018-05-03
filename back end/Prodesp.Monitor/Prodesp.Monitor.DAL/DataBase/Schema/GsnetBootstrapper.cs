using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using Prodesp.Core.NHibernate.DAL.Database.Util;
using Prodesp.Monitor.DAL.Mapper;
using Prodesp.Monitor.DAL.Model;

namespace Prodesp.Monitor.DAL.DataBase.Schema
{
    public class GsnetBootstrapper : OracleBootstrapper
    {
        public GsnetBootstrapper(string connectionStringName) : base(connectionStringName)
        {
        }

        protected override void SetupConfiguration(NHibernate.Cfg.Configuration cfg)
        {
            base.SetupConfiguration(cfg);

            ModelMapper mapper = new ModelMapper();


            // classes do estoque

            mapper.AddMapping<EmpenhoMapper>();
            mapper.AddMapping<EmpenhoMvtoMapper>();
            mapper.AddMapping<EventoMapper>();
            mapper.AddMapping<EventoMvtoMapper>();
            mapper.AddMapping<GestorMapper>();
            mapper.AddMapping<ItemMapper>();
            mapper.AddMapping<MensagemWsMapper>();
            mapper.AddMapping<ParametrosMapper>();
            mapper.AddMapping<ParamProgMapper>();
            mapper.AddMapping<ProcessoFilaMapper>();
            mapper.AddMapping<ProcessoMapper>();
            mapper.AddMapping<ProgramaSaudeMapper>();
            mapper.AddMapping<TpMotivoMapper>();
            mapper.AddMapping<TpAcaoMapper>();

            HbmMapping mapping = mapper.CompileMappingFor(new[]
            {

                // estoque
                typeof(Empenho),
                typeof(EmpenhoMvto),
                typeof(Evento),
                typeof(EventoMvto),
                typeof(Gestor),
                typeof(Item),
                typeof(MensagemWs),
                typeof(Parametros),
                typeof(ParamProg),
                typeof(ProcessoFila),
                typeof(Processo),
                typeof(ProgramaSaude),
                typeof(TpMotivo),
                typeof(TpAcao),

        });

            cfg.AddDeserializedMapping(mapping, null);
            cfg.AddAssembly("Prodesp.Monitor.DAL");
        }
    }
}
