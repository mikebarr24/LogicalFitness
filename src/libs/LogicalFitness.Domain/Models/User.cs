using System;
using System.ComponentModel.DataAnnotations;

namespace LogicalFitness.Domain.Models;

public class User(
    Guid id,
    string forename,
    string surname,
    string email,
    DateOnly? dateOfBirth,
    int? heightCm,
    decimal? weightKg,
    DateTimeOffset createdAt,
    DateTimeOffset updatedAt,
    bool isActive)
{
  public Guid Id { get; set; } = id;
  public string Forename { get; set; } = forename;
  public string Surname { get; set; } = surname;
  public string Email { get; set; } = email;
  public DateOnly? DateOfBirth { get; set; } = dateOfBirth;
  public int? HeightCm { get; set; } = heightCm;
  public decimal? WeightKg { get; set; } = weightKg;
  public DateTimeOffset CreatedAt { get; set; } = createdAt;
  public DateTimeOffset UpdatedAt { get; set; } = updatedAt;
  public bool IsActive { get; set; } = isActive;
}
