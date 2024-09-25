using CleanArchDemo.Infra.Data.University.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<UniversityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityCS")); // the Coonection string is on User Secrets
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
