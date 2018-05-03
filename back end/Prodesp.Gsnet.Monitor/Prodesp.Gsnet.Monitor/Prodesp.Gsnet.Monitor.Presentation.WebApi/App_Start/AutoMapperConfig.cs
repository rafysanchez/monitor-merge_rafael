using AutoMapper;
using Prodesp.Gsnet.Monitor.CrossCutting.TO.Mapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodesp.Gsnet.Monitor.Presentation.WebApi.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}