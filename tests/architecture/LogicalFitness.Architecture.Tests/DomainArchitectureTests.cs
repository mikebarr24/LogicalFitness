using NetArchTest.Rules;

namespace LogicalFitness.Architecture.Tests;

public class DomainArchitectureTests
{
  private const string DomainNamespace = "LogicalFitness.Domain";
  private const string ApplicationNamespace = "LogicalFitness.Application";
  private const string InfrastructureNamespace = "LogicalFitness.Infrastructure";
  private const string ApiNamespace = "LogicalFitness.Api";

  [Test]
  public async Task Domain_Should_Not_HaveDependencyOnOtherProjects()
  {
    //Arrange
    var assembly = typeof(Domain.AssemblyReference).Assembly;

    var otherProjects = new[]
    {
      ApplicationNamespace,
      InfrastructureNamespace,
      ApiNamespace
    };

    //Act
    var result = Types
      .InAssembly(assembly)
      .ShouldNot()
      .HaveDependencyOnAny(otherProjects)
      .GetResult();

    //Assert
    await Assert.That(result.IsSuccessful).IsTrue();
  }

  [Test]
  public async Task Domain_Should_Not_ReferenceDisallowedTypes()
  {
    // Arrange
    var domainAssembly = typeof(Domain.AssemblyReference).Assembly;

    var disallowedUsings = new[]
    {
      "Microsoft",
      "EntityFrameworkCore",
      "MediatR"
    };

    // Act
    var result = Types
      .InAssembly(domainAssembly)
      .ShouldNot()
      .HaveDependencyOnAll(disallowedUsings)
      .GetResult();

    // Assert
    await Assert.That(result.IsSuccessful).IsTrue();
  }

  [Test]
  public async Task Domain_Should_Not_ContainAnyDtos()
  {
    // Arrange
    var domainAssembly = typeof(Domain.AssemblyReference).Assembly;

    // Act
    var result = Types
      .InAssembly(domainAssembly)
      .ShouldNot()
      .HaveNameEndingWith("Dto")
      .GetResult();

    // Assert
    await Assert.That(result.IsSuccessful).IsTrue();
  }
}
