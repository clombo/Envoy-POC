using AutoMapper;
using Coffee.API.Interfaces;
using Coffee.API.Models;
using Coffee.Data.Context;
using Coffee.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coffee.API.Services;

public class CoffeeService : ICoffeeService
{
    private readonly IMapper _mapper;
    private readonly CoffeeDbContext _context;
    private readonly ILogger<CoffeeService> _logger;

    public CoffeeService(IMapper mapper, CoffeeDbContext context, ILogger<CoffeeService> logger)
    {
        _mapper = mapper;
        _context = context;
        _logger = logger;
    }
    
    public async Task<Guid> AddNewCoffee(CreateCoffeeRequestModel coffee)
    {
        try
        {
            var newCoffee = _mapper.Map<CoffeeEntity>(coffee);
            
            await _context.AddAsync(newCoffee);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Added new Coffee: {id}",newCoffee.Id);
        
            return newCoffee.Id;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }

    }

    public async Task<List<CoffeeResponseModel>> GetAllCoffees()
    {
        try
        {
            return _mapper.Map<List<CoffeeResponseModel>>(await _context.Coffee.Include(i => i.Ingredients).ToListAsync());
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
        
    }

    public async Task<CoffeeResponseModel?> GetCoffee(Guid id)
    {
        try
        {
            var coffee = await _context.Coffee.Include(i => i.Ingredients).FirstOrDefaultAsync(s => s.Id == id);
            return _mapper.Map<CoffeeResponseModel>(coffee);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }

    }

    public async Task<Guid?> DeleteCoffee(Guid id)
    {
        try
        {
            var coffeeToDelete = await _context.Coffee.FirstOrDefaultAsync(s => s.Id == id);

            if (coffeeToDelete is null)
                return null;
        
            _context.Remove(coffeeToDelete);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Deleted Coffee: {id}", coffeeToDelete.Id);

            return coffeeToDelete?.Id;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }

    }
}