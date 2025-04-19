using Xunit;
using FluentAssertions;

namespace EvaluationService.Tests;

public class EvaluationServiceBasicTests
{
    [Fact]
    public void DummyTest_ShouldPass()
    {
        true.Should().BeTrue();
    }
}
