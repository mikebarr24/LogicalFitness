using System;
using LogicalFitness.Application.Abstractions;
using LogicalFitness.Application.Services;

namespace LogicalFitness.Api.Extensions;

public static class ServiceExtensions
{
  public static void AddServices(this IServiceCollection services)
  {
    services.AddScoped<IUserService, UserService>();
  }
}
