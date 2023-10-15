using Coffee.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Data.Context;

public class CoffeeDbContext : DbContext
{
    public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options) : base(options)
    {}

    public DbSet<CoffeeEntity> Coffee{ get; set; }
    public DbSet<IngredientsEntity> Ingredients { get; set; }
}