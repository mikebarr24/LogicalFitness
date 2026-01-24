using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using LogicalFitness.Application.Abstractions;
using LogicalFitness.Application.Commands;
using LogicalFitness.Application.Dtos;
using LogicalFitness.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LogicalFitness.Application.Services;

public class UserService(
  IAppDbContext dbContext
) : IUserService
{
  public async Task<User> CreateUser(AddUserCommand command)
  {
    var newUser = new User(
      Guid.NewGuid(),
      command.Forename,
      command.Surname,
      command.Email,
      command.DateOfBirth,
      command.HeightCm,
      command.WeightKg,
      DateTimeOffset.UtcNow,
      DateTimeOffset.UtcNow,
      command.IsActive
    );

    return newUser;
  }

  public async Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken)
  {
    return await dbContext.Users.AnyAsync(u => u.Email == email, cancellationToken);
  }
}
