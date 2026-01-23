using FluentValidation;
using LogicalFitness.Api.Abstractions;
using LogicalFitness.Application.Commands;
using MediatR;

namespace LogicalFitness.Api.Endpoints;

public class AddUser : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("/api/users/add", async (
      AddUserCommand command,
      ISender sender,
      CancellationToken cancellationToken
    ) =>
    {
      await sender.Send(command, cancellationToken);
      return Results.Ok();
    }
    );
  }
}
