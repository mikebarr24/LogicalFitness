using System;
using FluentValidation;
using LogicalFitness.Application.Dtos;
using LogicalFitness.Application.Validators.Users;

namespace LogicalFitness.Api.Extensions;

public static class ValidationExtensions
{
  public static void AddValidators(this IServiceCollection services)
  {
    services.AddScoped<IValidator<UserDto>, UserDtoValidator>();
  }
}
