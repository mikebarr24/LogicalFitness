using System.Text.Json.Serialization;
using LogicalFitness.Application.Dtos;
using LogicalFitness.Domain.Models;
using LogicalFitness.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
  var connectionString = builder.Configuration.GetConnectionString("db-logical-fitness");
  options.UseNpgsql(connectionString, b => b.MigrationsAssembly("LogicalFitness.Api"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.MapPost("/api/users/add", async (UserDto userDto, AppDbContext db, CancellationToken cancellationToken, ILogger logger) =>
{
  try
  {
    var user = userDto.MapUserDtoToUser();

    await db.AddAsync(user, cancellationToken);
    await db.SaveChangesAsync(cancellationToken);

    return Results.Ok(user.Id);
  }
  catch (Exception ex)
  {
    logger.LogError(ex, "Failed to create user: {Email}", userDto?.Email);
    return Results.Problem("An error occurred when creating user.", statusCode: 500);
    throw;
  }
});

app.UseHttpsRedirection();

app.Run();