using System.Globalization;
using AutoMapper;
using Beer.Api.Models;
using Beer.Data.Entities;

namespace Beer.Api.Mappings;

public class BeerEntityMapping : Profile
{
    public BeerEntityMapping()
    {
        CreateBeerResponseEntityMapping();
        CreateBeerRequestEntityMapping();
    }

    private void CreateBeerRequestEntityMapping()
    {
        CreateMap<CreateBeerRequestModel, BeerEntity>()
            .ForMember(d => d.Id, o => o.MapFrom(s => Guid.NewGuid()))
            .ForMember(d => d.AverageRating, o => o.MapFrom(s => s.Rating.Average))
            .ForMember(d => d.TotalReviews, o => o.MapFrom(s => s.Rating.Reviews));
    }

    private void CreateBeerResponseEntityMapping()
    {
        CreateMap<BeerEntity, BeerResponseModel>()
            .ForMember(
                d => d.Price,
                o => o.MapFrom(s => string.Format(new CultureInfo("en-ZA"), "{0:C}", s.Price))
            )
            .ForMember(
                d => d.Rating,
                o => o.MapFrom(s => new Rating {Average = s.AverageRating, Reviews = s.TotalReviews})
            );

    }
}