namespace Beer.Api.Models;

public class CreateBeerRequestModel
{
    public double Price { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public Rating Rating { get; set; }
}