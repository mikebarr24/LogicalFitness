using System;
using FluentValidation;
using LogicalFitness.Application.Abstractions;

namespace LogicalFitness.Application.Commands.Users;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
  public AddUserCommandValidator(IUserService userService)
  {
    RuleFor(x => x.Forename)
      .NotEmpty()
      .NotNull();
    RuleFor(x => x.Surname)
      .NotEmpty()
      .NotNull();
    RuleFor(x => x.Email)
      .EmailAddress()
      .NotEmpty()
      .NotNull()
      .MustAsync(async (email, cancellationToken) =>
        !await userService.EmailExistsAsync(email, cancellationToken)
      )
      .WithMessage("Email already Exists");
    RuleFor(x => x.IsActive)
      .NotNull();
  }
}
