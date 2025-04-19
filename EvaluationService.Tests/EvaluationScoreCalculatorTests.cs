using Xunit;
using FluentAssertions;
using Moq;
using EvaluationService;

namespace EvaluationService.Tests;

public class EvaluationScoreCalculatorTests
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
