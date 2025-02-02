using AutoMapper;
using DSV.WebApi.Models;

namespace DSV.WebApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Provider, Core.Domain.Entities.Providers.Provider>();
        CreateMap<Core.Domain.Entities.Providers.Provider, Provider>();
        
        CreateMap(typeof(Core.Domain.Entities.Common.ResultSet<>), typeof(ResultSet<>));
    }
}