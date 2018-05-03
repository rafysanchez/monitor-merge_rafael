using AutoMapper;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels;
using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.Mapper.Helpers
{
    public static class Helpers
    {
        
    }
    public class TipoAcaoVMResolver : IValueResolver<MotivoAcaoViewModel, MotivoAcao, string>
    {
        public string Resolve(MotivoAcaoViewModel source, MotivoAcao destination, string destMember, ResolutionContext context)
        {
            return source.Situacao ? "S" : "N";
        }
    }
}
