using Coffee.API.Interfaces;
using Coffee.API.Services;
using Coffee.Data;
using Coffee.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

//Add db context
services.AddDb(config);

//Add automapper
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add services
services.AddScoped<ICoffeeService,CoffeeService>();

// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

//Run migrations
Console.WriteLine("Starting Migrations");
using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetRequiredService<CoffeeDbContext>();
        context.Database.Migrate();
        Console.WriteLine("Migration completed");
    }
    catch (Exception e)
    {
        Console.WriteLine("Migration failed: " + e.Message);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();