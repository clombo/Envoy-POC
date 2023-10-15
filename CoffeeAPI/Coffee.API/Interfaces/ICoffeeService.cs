using Coffee.API.Models;

namespace Coffee.API.Interfaces;

public interface ICoffeeService
{
    Task<Guid> AddNewCoffee(CreateCoffeeRequestModel coffee);
    Task<List<CoffeeResponseModel>> GetAllCoffees();
    Task<CoffeeResponseModel?> GetCoffee(Guid id);
    Task<Guid?> DeleteCoffee(Guid id);
    
}