namespace Coffee.Data.Entities;

public class CoffeeEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<IngredientsEntity> Ingredients { get; set; }
    public string Image { get; set; }
}