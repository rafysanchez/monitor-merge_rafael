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
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() : base()
        {
            CreateMap<MotivoAcao, MotivoAcaoViewModel>()
                .AfterMap((src, dest) => dest.Tipo = src.Tipo == 0 ? "Ação" : "Motivo")
                .ForMember(dest => dest.Situacao, src => src.MapFrom(x => x.FlagAtivo == "S"));

            CreateMap<ItemMonitoramento, ItemMonitoramentoViewModel>()
                .ForMember(x => x.Local, i => i.Ignore())
                .ForMember(x => x.Nome, i => i.Ignore())
                .ForMember(x => x.GrupoRecursos, i => i.Ignore())
                .ForMember(x => x.UnidadeDistribuicao, i => i.Ignore())
                .ForMember(x => x.Justificado, i => i.Ignore())
                .AfterMap((src, dest) => dest.DataUltimoConsumo = src.DataUltimoConsumo?.ToShortDateString() ?? "")
                .AfterMap((src, dest) => dest.DataUltimaFatura = src.DataUltimaFatura?.ToShortDateString() ?? "")
                .AfterMap((src, dest) => dest.DataUltimoEmpenho = src.DataUltimoEmpenho?.ToShortDateString() ?? "");

            CreateMap<ItemMonitoramentoDTO, ItemAlertaMonitorViewModel>()               
                .AfterMap((src, dest) => dest.DataUltimoConsumo = src.DataUltimoConsumo?.ToShortDateString() ?? "")
                .AfterMap((src, dest) => dest.DataUltimaFatura = src.DataUltimaFatura?.ToShortDateString() ?? "")
                .AfterMap((src, dest) => dest.DataUltimoEmpenho = src.DataUltimoEmpenho?.ToShortDateString() ?? "");

            CreateMap<Justificativa, JustificativaViewModel>()
                .AfterMap((src, dest) => dest.DataJustificativa = src.DataJustificativa.ToShortDateString());

            CreateMap<HistoricoJustificativaDTO, ListHistoricoJustificativaViewModel>()
                .ForMember(x => x.DataMonitoramentoExtenso, i => i.Ignore())
                .ForMember(x => x.DataMonitoramentoExtenso, i => i.Ignore())
                .AfterMap((src, dest) => dest.JustificativaCAF = src.JustificativaCAF?.ToString() ?? "")
                .AfterMap((src, dest) => dest.JustificativaCAFPublica = src.JustificativaCAFPublica?.ToString() ?? "")
                .AfterMap((src, dest) => dest.JustificativaFME = src.JustificativaFME?.ToString() ?? "")
                .AfterMap((src, dest) => dest.JustificativaCompras = (src.JustificativaCompras?.ToString()) ?? "")
                .AfterMap((src, dest) => dest.DataMonitoramento = src.DataMonitoramento?.ToShortDateString())
                .AfterMap((src, dest) => dest.DataInicioVigencia = src.DataInicioVigencia.ToString("dd/MM/yyyy HH:mm"))
                .AfterMap((src, dest) => dest.DataMonitoramentoExtenso = src.DataMonitoramento?.ToLongDateString())
                .AfterMap((src, dest) => dest.DataUltimaFatura = src.DataUltimaFatura?.ToShortTimeString() ?? "")
                .AfterMap((src, dest) => dest.DataUltimoEmpenho = src.DataUltimoEmpenho?.ToShortTimeString() ?? "")
                .AfterMap((src, dest) => dest.SaldoDisponivel = src.SaldoDisponivel.GetValueOrDefault().ToString("0.0"))
                .AfterMap((src, dest) => dest.ConsumoMedex = src.ConsumoMedex.GetValueOrDefault().ToString("0.0"));



            //CreateMap<IndicadoresMonitoramento, IndicadoresViewModel>()
            //    .ForMember(x=> x.Percentual ,i=> i.Ignore())
            //    .AfterMap((src, dest) => dest.DataMonitoramento = src.DataMonitoramento.ToShortDateString())
            //    .AfterMap((src, dest) => dest.Percentual = $"{((src.QuantidadeAlertasItens * 100) / src.QuantidadeItens )} %");

            CreateMap<RegraMotor, RegraMotorViewModel>()
                .ForMember(x => x.NomePrograma, i => i.Ignore())
                .ForMember(x => x.NomeTipoParametro, i => i.Ignore())
                .ForMember(x => x.IdUsuario, i => i.Ignore())

             .AfterMap((src, dest) => dest.NomeTipoParametro = src.TpParametro == 1 ? "Autonomia Consumo " : "Saldo Zerado")
             .AfterMap((src, dest) => dest.NomePrograma = src.PogramaSaude.NomePrograma);

        }
    }
}