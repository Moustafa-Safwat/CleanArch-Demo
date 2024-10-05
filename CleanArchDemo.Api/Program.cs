using CleanArchDemo.Infra.Data.University.Context;
using Microsoft.EntityFrameworkCore;
using CleanArchDemo.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.RegisterServices() // Register the services
                .RegiserAutoMapper(); // Register Automapper

builder.Services.AddDbContext<UniversityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityCS")); // the Coonection string is on User Secrets
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
    CleanArchDemo.Application.AssemblyReference.Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
