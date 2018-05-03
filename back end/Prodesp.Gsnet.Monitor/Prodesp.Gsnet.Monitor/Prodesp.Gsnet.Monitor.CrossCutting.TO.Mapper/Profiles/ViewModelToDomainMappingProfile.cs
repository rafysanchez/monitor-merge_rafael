using AutoMapper;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels;
using Prodesp.Gsnet.Monitor.Domain.DTO;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.Mapper.Profiles
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() : base()
        {

            CreateMap<MotivoAcaoViewModel, MotivoAcao>()
             .ForMember(x => x.ValidationResult, i => i.Ignore())
             .ForMember(x => x.FlagAtivo, i => i.Ignore())
             .ForMember(x => x.IsValid, i => i.Ignore())
             .ForMember(dest => dest.Tipo, opt => opt.ResolveUsing(src => src.Tipo == "Motivo" ? (short)1 : (short)0))
             .AfterMap((src, dest) => dest.FlagAtivo = src.Situacao ? "S" : "N");

            CreateMap<ItemMonitoramentoViewModel, ItemMonitoramento>()
                .ForMember(x => x.ValidationResult, i => i.Ignore())
                .ForMember(x => x.IsValid, i => i.Ignore())
                .ForMember(x => x.Monitoramento, i => i.Ignore())
                .ForMember(x => x.Usuario, i => i.Ignore())
                .ForMember(x => x.ItemProgramaGestor, i => i.Ignore());

            CreateMap<JustificativaViewModel, Justificativa>()
                 .ForMember(x => x.ValidationResult, i => i.Ignore())
                 .ForMember(x => x.IsValid, i => i.Ignore());
            CreateMap<ListHistoricoJustificativaViewModel, HistoricoJustificativaDTO>()
                .ForMember(x => x.TipoConsumo, i => i.Ignore())
                .ForMember(x => x.NomeFarmacia, i => i.Ignore())
                .ForMember(x => x.NomeMedicamento, i => i.Ignore())
                .ForMember(x => x.IdItemMonitoramento, i => i.Ignore());

            CreateMap<RegraMotorViewModel, RegraMotor>()
                .ForMember(x => x.ValidationResult, i => i.Ignore())
                .ForMember(x => x.IsValid, i => i.Ignore())
                .ForMember(x => x.FlStatus, i => i.Ignore())
                .ForMember(x => x.IdUsuario, i => i.Ignore())
                .ForMember(x => x.PogramaSaude, i => i.Ignore());



        }
    }
}
