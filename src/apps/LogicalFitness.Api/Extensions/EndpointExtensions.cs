using System;
using System.Reflection;
using LogicalFitness.Api.Abstractions;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LogicalFitness.Api.Extensions;

public static class EndpointExtensions
{
  public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
  {
    var endpointServiceDescriptors = assembly
      .DefinedTypes
      .Where(type => type is { IsAbstract: false, IsInterface: false } &&
              type.IsAssignableTo(typeof(IEndpoint)))
      .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
      .ToArray();

    services.TryAddEnumerable(endpointServiceDescriptors);

    return services;
  }

  public static IApplicationBuilder MapEndpoints(this WebApplication app)
  {
    var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

    foreach (IEndpoint endpoint in endpoints)
    {
      endpoint.MapEndpoint(app);
    }

    return app;
  }
}