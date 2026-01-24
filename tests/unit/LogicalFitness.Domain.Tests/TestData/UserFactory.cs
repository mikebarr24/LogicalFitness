using System;
using LogicalFitness.Domain.Models;

namespace LogicalFitness.Domain.Tests.TestData;

public static class UserFactory
{
  public static User Create(
    Guid? id = null,
    string forename = "Taylor",
    string surname = "Jordan",
    string email = "taylor.jordan@example.com",
    DateOnly? dateOfBirth = null,
    int? heightCm = 180,
    decimal? weightKg = 75.5m,
    DateTimeOffset? createdAt = null,
    DateTimeOffset? updatedAt = null,
    bool isActive = true)
  {
    var now = DateTimeOffset.UtcNow;

    return new User(
      id ?? Guid.NewGuid(),
      forename,
      surname,
      email,
      dateOfBirth,
      heightCm,
      weightKg,
      createdAt ?? now,
      updatedAt ?? now,
      isActive);
  }
}
