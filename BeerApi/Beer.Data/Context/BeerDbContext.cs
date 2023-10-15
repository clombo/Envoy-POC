using Beer.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Beer.Data.Context;

public class BeerDbContext : DbContext
{
    public BeerDbContext(DbContextOptions<BeerDbContext> options) : base(options) 
    {}
    public DbSet<BeerEntity> Beer { get; set; }
}