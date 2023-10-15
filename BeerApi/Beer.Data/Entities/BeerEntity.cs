namespace Beer.Data.Entities;

public class BeerEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
    public double AverageRating { get; set; }
    public int TotalReviews { get; set; }
}