using Beer.Api.Interfaces;
using Beer.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Beer.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BeerController : ControllerBase
{
    private readonly ILogger<BeerController> _logger;
    private readonly IBeerService _beerService;

    public BeerController(ILogger<BeerController> logger, IBeerService beerService)
    {
        _logger = logger;
        _beerService = beerService;
    }
    
    //Add
    [HttpPost]
    public async Task<IActionResult> AddBeer([FromBody] CreateBeerRequestModel request)
    {
        return Ok(await _beerService.AddNewBeer(request));
    }
    
    //Delete
    [HttpDelete]
    public async Task<IActionResult> DeleteBeer(Guid id)
    {
        var deletedBeer = await _beerService.DeleteBeer(id);
        
        if(deletedBeer is null || deletedBeer == Guid.Empty)
            return NotFound();
        
        return Ok(deletedBeer);
    }
    
    //Get
    [HttpGet]
    public async Task<IActionResult> GetBeer(Guid id)
    {
        var beer = await _beerService.GetBeer(id);

        if (beer is null)
            return NotFound();
        
        return Ok(beer);
    }
    
    //Get All
    [HttpGet("all")]
    public async Task<IActionResult> GetAllBeers()
    {
        return Ok(await _beerService.GetBeers());
    }
    
}