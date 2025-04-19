using Xunit;
using FluentAssertions;
using Moq;
using PriorityService;

namespace PriorityService.Tests;

public class PriorityRulesEvaluatorTests
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
