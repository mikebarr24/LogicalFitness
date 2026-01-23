using System;
using NetArchTest.Rules;

namespace LogicalFitness.Architecture.Tests;

public class ArchitectureTests
{
  private const string DomainNamespace = "Domain";
  private const string ApplicationNamespace = "Application";
  private const string InfustructureNamespace = "Infustructure";
  private const string ApiNamespace = "Api";

  [Test]
  public async Task Domain_Should_Not_HaveDependencyOnOtherProjects()
  {
    //Arrange
    var assembly = typeof(Domain.AssemblyReference).Assembly;

    var otherProjects = new[]
    {
      ApplicationNamespace,
      InfustructureNamespace,
      ApiNamespace
    }
    ;

    //Act
    var result = Types
      .InAssembly(assembly)
      .ShouldNot()
      .HaveDependencyOnAll(otherProjects)
      .GetResult();

    //Assert
    await Assert.That(result.IsSuccessful).IsTrue();
  }
}
