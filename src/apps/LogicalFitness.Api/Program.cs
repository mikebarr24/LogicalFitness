using System.Reflection;
using LogicalFitness.Api.Extensions;
using LogicalFitness.Application.Abstractions;
using LogicalFitness.Application.Commands.Users;
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
  options.UseNpgsql(connectionString, options => options.MigrationsAssembly("LogicalFitness.Api"));
});

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());
builder.Services.AddValidators();
builder.Services.AddServices();

builder.Services.AddMediatR(cfg =>
{
  cfg.LicenseKey = "mediatr-key";
  cfg.RegisterServicesFromAssemblies(
    typeof(Program).Assembly,
    typeof(AddUserCommandHandler).Assembly
);
});

builder.Services.AddScoped<IAppDbContext, AppDbContext>();

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