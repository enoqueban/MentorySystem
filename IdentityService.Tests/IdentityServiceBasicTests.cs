using Xunit;
using FluentAssertions;

namespace IdentityService.Tests;

public class IdentityServiceBasicTests
{
    [Fact]
    public void DummyTest_ShouldPass()
    {
        true.Should().BeTrue();
    }
}
