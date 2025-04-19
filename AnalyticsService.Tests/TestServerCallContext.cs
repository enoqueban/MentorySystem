using Grpc.Core;
using Moq;

namespace AnalyticsService.Tests
{
    // Helper class to create a mock ServerCallContext for testing
    public static class TestServerCallContextFactory
    {
        public static ServerCallContext Create(string method, string? host, DateTime deadline,
            Metadata requestHeaders, CancellationToken cancellationToken, string peer,
            AuthContext? authContext, ContextPropagationToken? propagationToken,
            Metadata? responseTrailers, WriteOptions? writeOptions)
        {
            var mockContext = new Mock<ServerCallContext>();
            mockContext.Setup(m => m.Method).Returns(method);
            mockContext.Setup(m => m.Host).Returns(host ?? "localhost");
            mockContext.Setup(m => m.Deadline).Returns(deadline);
            mockContext.Setup(m => m.RequestHeaders).Returns(requestHeaders);
            mockContext.Setup(m => m.CancellationToken).Returns(cancellationToken);
            mockContext.Setup(m => m.Peer).Returns(peer);
            mockContext.Setup(m => m.AuthContext).Returns(authContext ?? new AuthContext(string.Empty, new Dictionary<string, List<AuthProperty>>()));
            
            if (responseTrailers != null)
                mockContext.Setup(m => m.ResponseTrailers).Returns(responseTrailers);
            
            if (writeOptions != null)
                mockContext.Setup(m => m.WriteOptionsAsync(It.IsAny<WriteOptions>())).Returns(Task.FromResult(writeOptions));
            
            return mockContext.Object;
        }
    }
}