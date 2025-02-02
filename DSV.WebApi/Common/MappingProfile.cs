using AutoMapper;
using DSV.WebApi.Models;
using DSV.WebApi.Models.Providers;

namespace DSV.WebApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Provider, Core.Domain.Entities.Providers.Provider>();
        CreateMap<Core.Domain.Entities.Providers.Provider, Provider>();
        
        CreateMap<Core.Domain.Entities.Services.Service, Service>();
        
        CreateMap(typeof(Core.Domain.Entities.Common.ResultSet<>), typeof(ResultSet<>));
    }
}