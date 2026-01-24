using System;
using LogicalFitness.Domain.Tests.TestData;

namespace LogicalFitness.Domain.Tests.Models;

public class UserTests
{
  [Test]
  public async Task Domain_User_Should_ContainRelevantProps()
  {
    // Arrange
    var user = UserFactory.Create();
    // Act

    // Assert
    await Assert.That(user.Id).IsNotEqualTo(Guid.Empty);
    await Assert.That(user.Forename).IsEqualTo("Taylor");
    await Assert.That(user.Surname).IsEqualTo("Jordan");
    await Assert.That(user.Email).IsEqualTo("taylor.jordan@example.com");
    await Assert.That(user.CreatedAt).IsNotEqualTo(default);
    await Assert.That(user.UpdatedAt).IsNotEqualTo(default);
    await Assert.That(user.IsActive).IsTrue();
  }
}
