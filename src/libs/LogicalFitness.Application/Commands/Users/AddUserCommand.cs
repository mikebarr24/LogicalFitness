using LogicalFitness.Application.Commands.Common;
using MediatR;

namespace LogicalFitness.Application.Commands;

public record AddUserCommand(
  string Forename,
  string Surname,
  string Email,
  DateOnly? DateOfBirth,
  int? HeightCm,
  decimal? WeightKg,
  bool IsActive
) : BaseCommand<Guid>;
