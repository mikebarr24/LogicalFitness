using System;
using LogicalFitness.Api.Abstractions;
using LogicalFitness.Application.Dtos;
using LogicalFitness.Infrastructure.Data;

namespace LogicalFitness.Api.Endpoints;

public class AddUser(ILogger<AddUser> logger) : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("/api/users/add", async (UserDto userDto, AppDbContext db, CancellationToken cancellationToken) =>
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
  }
}
