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
  [Key]
  public Guid Id { get; init; } = id;
  [Required]
  public string Forename { get; set; } = forename;
  [Required]
  public string Surname { get; set; } = surname;
  [EmailAddress]
  [Required]
  public string Email { get; set; } = email;
  public DateOnly? DateOfBirth { get; set; } = dateOfBirth;
  public int? HeightCm { get; set; } = heightCm;
  public decimal? WeightKg { get; set; } = weightKg;
  public DateTimeOffset CreatedAt { get; set; } = createdAt;
  public DateTimeOffset UpdatedAt { get; set; } = updatedAt;
  public bool IsActive { get; set; } = isActive;
}
