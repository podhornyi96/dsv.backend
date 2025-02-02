using AutoMapper;
using DSV.WebApi.Models;
using DSV.WebApi.Models.Providers;
using DSV.WebApi.Models.ProviderServices;

namespace DSV.WebApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Provider, Core.Domain.Entities.Providers.Provider>();
        CreateMap<Core.Domain.Entities.Providers.Provider, Provider>();
        
        CreateMap<Core.Domain.Entities.Services.Service, Service>();
        
        CreateMap<Core.Domain.Entities.Providers.ProviderService, ProviderService>();
        
        CreateMap(typeof(Core.Domain.Entities.Common.ResultSet<>), typeof(ResultSet<>));
    }
}