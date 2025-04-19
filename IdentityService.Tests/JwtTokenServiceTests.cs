using Xunit;
using FluentAssertions;
using Moq;
using IdentityService.Services;

namespace IdentityService.Tests;

public class JwtTokenServiceTests
{
    [Fact]
    public void DummyTest_ShouldPass()
    {
        // Arrange
        var expected = 1;

        // Act
        var actual = 1;

        // Assert
        actual.Should().Be(expected);
    }
}
