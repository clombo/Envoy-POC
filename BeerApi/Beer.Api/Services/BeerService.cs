using AutoMapper;
using Beer.Api.Interfaces;
using Beer.Api.Models;
using Beer.Data.Context;
using Beer.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Beer.Api.Services;

public class BeerService : IBeerService
{
    private readonly BeerDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<BeerService> _logger;

    public BeerService(BeerDbContext context, IMapper mapper, ILogger<BeerService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Guid> AddNewBeer(CreateBeerRequestModel beer)
    {
        try
        {
            var newBeer = _mapper.Map<BeerEntity>(beer);
        
            await _context.AddAsync(newBeer);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Added new Beer: {id}",newBeer.Id);

            return newBeer.Id;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task<BeerResponseModel?> GetBeer(Guid id)
    {
        
        try
        {
            return _mapper.Map<BeerResponseModel>(await _context.Beer.FirstOrDefaultAsync(s => s.Id == id));
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
        
    }

    public async Task<List<BeerResponseModel>> GetBeers()
    {
        try
        {
            return _mapper.Map<List<BeerResponseModel>>(await _context.Beer.ToListAsync());
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
        
    }

    public async Task<Guid?> DeleteBeer(Guid id)
    {
        try
        {
            var deletedBeer = await _context.Beer.FirstOrDefaultAsync(s => s.Id == id);

            if (deletedBeer is null)
                return null;

            _context.Remove(deletedBeer);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Deleted Beer: {id}",deletedBeer.Id);

            return deletedBeer.Id;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
        

    }
}