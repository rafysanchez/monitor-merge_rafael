using Oracle.ManagedDataAccess.Client;
using Prodesp.Core.EntityFramework;
using Prodesp.Gsnet.Framework;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations;
using Prodesp.Gsnet.Monitor.Infra.Data.EF.Interceptors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF
{
    public class MonitorConfiguration : DbConfiguration
    {
        public MonitorConfiguration()
        {
            this.AddInterceptor(new NVarcharInterceptor()); //add this line to existing config.
        }
    }
    [DbConfigurationType(typeof(MonitorConfiguration))]
    public class Contexto : EncryptedDbContext
    {
        public Contexto() : base(ConfigurationManager.ConnectionStrings["GSNET"].ConnectionString, HelperConstants.GsnetMonitorSchema)
        {
           
        }

        #region [DbSets]
        public virtual DbSet<MotivoAcao> MotivosAcoes { get; set; }

        public virtual DbSet<Monitoramento> Monitoramentos { get; set; }

        public virtual DbSet<ItemMonitoramento> ItensMonitoramentos { get; set; }

        public virtual DbSet<Item> Itens { get; set; }

        public virtual DbSet<ItemProgramaSaude> ItensProgramaSaude { get; set; }

        public virtual DbSet<ItemProgramaGestor> ItensProgramaGestor { get; set; }

        public virtual DbSet<UnidadeMedida> UnidadesMedida { get; set; }

        public virtual DbSet<Justificativa> Justificativas { get; set; }

        public virtual DbSet<Gestor> Gestores { get; set; }
        public virtual DbSet<IndicadoresMonitoramento> Indicadores { get; set; }

        public virtual DbSet<Parametro> Parametros { get; set; }
        public virtual DbSet<RegraMotor> RegraMotors { get; set; }

        public virtual DbSet<ProgramaSaude> ProgramaSaudes { get; set; }

        public virtual DbSet<ParametroValor> ParametroValors { get; set; }
        #endregion

        #region [EncryptedDbContext Overrides]     
        public override void ApplyConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MotivoAcaoConfiguration());
            modelBuilder.Configurations.Add(new ItemMonitoramentoConfiguration());
            modelBuilder.Configurations.Add(new UnidadeMedidaConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new ItemProgramaGestorConfiguration());
            modelBuilder.Configurations.Add(new ItemProgramaSaudeConfiguration());
            modelBuilder.Configurations.Add(new JustificativaConfiguration());
            modelBuilder.Configurations.Add(new IndicadoresMonitoramentoConfiguration());
            modelBuilder.Configurations.Add(new GestorConfiguration());
            modelBuilder.Configurations.Add(new MonitoramentoConfiguration());
            modelBuilder.Configurations.Add(new ParametroConfiguration());
            modelBuilder.Configurations.Add(new RegraMotorConfiguration());
            modelBuilder.Configurations.Add(new ProgramaSaudeConfiguration());
            modelBuilder.Configurations.Add(new ParametroValorConfiguration());
        }
        #endregion
    }
}
