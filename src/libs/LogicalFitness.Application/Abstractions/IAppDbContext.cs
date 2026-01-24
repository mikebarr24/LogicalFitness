using System;
using LogicalFitness.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LogicalFitness.Application.Abstractions;

public interface IAppDbContext
{
  DbSet<User> Users { get; }
  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
