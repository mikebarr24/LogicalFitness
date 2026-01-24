using System;
using FluentValidation;
using LogicalFitness.Application.Dtos;

namespace LogicalFitness.Application.Validators.Users;

public class UserDtoValidator : AbstractValidator<UserDto>
{
  public UserDtoValidator()
  {
    RuleFor(user => user.Forename)
      .NotNull()
      .NotEmpty();
    RuleFor(user => user.Surname)
      .NotNull()
      .NotEmpty();
    RuleFor(user => user.Email)
      .EmailAddress()
      .NotNull()
      .NotEmpty();
  }
}
