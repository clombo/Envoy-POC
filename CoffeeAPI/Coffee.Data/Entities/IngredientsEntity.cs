namespace Coffee.Data.Entities;

public class IngredientsEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CoffeeId { get; set; }
    public CoffeeEntity Coffee { get; set; }
}