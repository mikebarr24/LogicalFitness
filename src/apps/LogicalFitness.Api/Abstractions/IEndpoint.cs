using System;
using Microsoft.AspNetCore.Mvc;

namespace LogicalFitness.Api.Abstractions;

public interface IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app);
}
