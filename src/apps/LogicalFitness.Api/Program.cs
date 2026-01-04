using System.Reflection;
using System.Text.Json.Serialization;
using LogicalFitness.Api.Extensions;
using LogicalFitness.Application.Dtos;
using LogicalFitness.Domain.Models;
using LogicalFitness.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
  var connectionString = builder.Configuration.GetConnectionString("db-logical-fitness");
  options.UseNpgsql(connectionString, b => b.MigrationsAssembly("LogicalFitness.Api"));
});

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();

  app.UseSwagger();
  app.UseSwaggerUI();
}

app.MapEndpoints();

app.UseHttpsRedirection();

app.Run();