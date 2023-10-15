namespace Coffee.API.Models;

public class CreateCoffeeRequestModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string[] Ingredients { get; set; }
}