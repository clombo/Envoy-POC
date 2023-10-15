namespace Beer.Api.Models;

public class BeerResponseModel
{
    public Guid Id { get; set; }
    public string Price { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public Rating Rating { get; set; }
}