using Beer.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Beer.Data;

public static class ServiceExtension
{

    public static IServiceCollection AddDb(this IServiceCollection service, IConfiguration config)
    {
        service.AddDbContext<BeerDbContext>(
            options => options.UseNpgsql(
                config.GetConnectionString("DB"),
                x => x.MigrationsHistoryTable("__MyMigrationHistory")
            )
        );
        return service;
    }
    
}