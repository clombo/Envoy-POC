using Coffee.API.Interfaces;
using Coffee.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CoffeeController : ControllerBase
{
    private readonly ILogger<CoffeeController> _logger;
    private readonly ICoffeeService _coffeeService;

    public CoffeeController(ILogger<CoffeeController> logger, ICoffeeService coffeeService)
    {
        _logger = logger;
        _coffeeService = coffeeService;
    }
    
    //Get single
    [HttpGet]
    public async Task<IActionResult> GetCoffee(Guid id)
    {
        var coffee = await _coffeeService.GetCoffee(id);
        
        if (coffee == null)
            return NotFound();
        
        return Ok(coffee);
    }
    
    //Get all
    [HttpGet("all")]
    public async Task<IActionResult> GetAllCoffees()
    {
        var allCoffees = await _coffeeService.GetAllCoffees();
        return Ok(allCoffees);
    }
    
    //Delete
    [HttpDelete]
    public async Task<IActionResult> DeleteCoffee(Guid id)
    {
        var deletedCoffee = await _coffeeService.DeleteCoffee(id);
        
        if(deletedCoffee == null || deletedCoffee == Guid.Empty)
            return NotFound();

        return Ok(deletedCoffee);
    }
    
    //Add
    [HttpPost]
    public async Task<IActionResult> CreateCoffee([FromBody] CreateCoffeeRequestModel request)
    {
        return Ok(await _coffeeService.AddNewCoffee(request));
    }
}