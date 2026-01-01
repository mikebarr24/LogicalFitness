using System;
using System.Text.Json.Serialization;
using LogicalFitness.Domain.Models;

namespace LogicalFitness.Application.Dtos;

public record UserDto(
  Guid Id,
  string Forename,
  string Surname,
  string Email,
  DateOnly? DateOfBirth,
  int? HeigthCm,
  decimal? WeightKg,
  DateTimeOffset CreatedAt,
  DateTimeOffset UpdatedAt,
  bool IsActive
);


public static class UserDtoExtensions
{
  public static User MapUserDtoToUser(this UserDto userDto)
  {
    return new User(
      userDto.Id,
      userDto.Forename,
      userDto.Surname,
      userDto.Email,
      userDto.DateOfBirth,
      userDto.HeigthCm,
      userDto.WeightKg,
      userDto.CreatedAt,
      userDto.UpdatedAt,
      userDto.IsActive
    );
  }
}