using System;

namespace LogicalFitness.Api.Abstractions;

public interface IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app);
}
