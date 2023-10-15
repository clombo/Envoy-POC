using Beer.Api.Models;

namespace Beer.Api.Interfaces;

public interface IBeerService
{
    Task<Guid> AddNewBeer(CreateBeerRequestModel beer);
    Task<BeerResponseModel?> GetBeer(Guid id);
    Task<List<BeerResponseModel>> GetBeers();
    Task<Guid?> DeleteBeer(Guid id);
}