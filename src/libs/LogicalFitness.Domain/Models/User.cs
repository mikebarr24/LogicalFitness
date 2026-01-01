using System;
using System.ComponentModel.DataAnnotations;

namespace LogicalFitness.Domain.Models;

public class User
{
  [Key]
  public Guid Id { get; init; }
  [Required]
  public string Forename { get; set; } = string.Empty;
  [Required]
  public string Surname { get; set; } = string.Empty;
  [EmailAddress]
  [Required]
  public string Email { get; set; } = string.Empty;
  public DateOnly? DateOfBirth { get; set; }
  public decimal? HeightCm { get; set; }
  public decimal? WeightKg { get; set; }
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
  public bool IsActive { get; set; }
}
