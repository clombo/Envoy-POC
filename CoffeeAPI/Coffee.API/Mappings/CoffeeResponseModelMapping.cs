using AutoMapper;
using Coffee.API.Models;
using Coffee.Data.Entities;

namespace Coffee.API.Mappings;

public class CoffeeResponseModelMapping : Profile
{
    public CoffeeResponseModelMapping()
    {
        CreateResponseMapping();
    }

    private void CreateResponseMapping()
    {
        CreateMap<CoffeeEntity, CoffeeResponseModel>()
            .ForMember(
                d => d.Ingredients,
                o =>
                    o.MapFrom(
                        s => s.Ingredients.Select(c => c.Name))
            );
    }
}