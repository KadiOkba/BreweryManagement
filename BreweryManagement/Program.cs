using MediatR;
using System.Reflection;
using BreweryManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using BreweryManagement.API.Middlewares;
using BreweryManagement.Application.Infrastructure;
using BreweryManagement.Application.Beers.Commands.Create;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

     
// Add MediatR
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
services.AddMediatR(x=>x.RegisterServicesFromAssembly(typeof(CreateBeerCommand).GetTypeInfo().Assembly));

services.AddDbContext<BreweryDb>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("BreweryDb")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetService<BreweryDb>();
        context!.Database.Migrate();
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating or initializing the database.");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
