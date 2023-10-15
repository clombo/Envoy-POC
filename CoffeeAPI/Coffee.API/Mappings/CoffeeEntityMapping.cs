using AutoMapper;
using Coffee.API.Models;
using Coffee.Data.Entities;

namespace Coffee.API.Mappings;

public class CoffeeEntityMapping : Profile
{
    public CoffeeEntityMapping()
    {
        CreateCoffeeRequestModelMapping();
    }
    

    private void CreateCoffeeRequestModelMapping()
    {
        CreateMap<CreateCoffeeRequestModel, CoffeeEntity>()
            .ForMember(d => d.Id, o => o.MapFrom(s => Guid.NewGuid()));
        CreateMap<string, IngredientsEntity>()
            .ForMember(d => d.Id, o => o.MapFrom(s => Guid.NewGuid()))
            .ForMember(d => d.Name, o => o.MapFrom(s => s));

    }
}