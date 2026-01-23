using System;
using LogicalFitness.Application.Commands;
using LogicalFitness.Application.Dtos;
using LogicalFitness.Domain.Models;

namespace LogicalFitness.Application.Abstractions;

public interface IUserService
{
  public Task<User> CreateUser(AddUserCommand command);
  public Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken);
}
