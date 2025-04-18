using System.Threading.Tasks;
using Xunit;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.SignalR;
using ChatService.Hubs;

namespace ChatService.Tests
{
    public class ChatHubTests
    {
        [Fact]
        public async Task SendMessage_ShouldCallReceiveMessageOnClients()
        {
            // Arrange
            var mockClients = new Mock<IHubCallerClients>();
            var mockClientProxy = new Mock<IClientProxy>();
            var mockContext = new Mock<HubCallerContext>();

            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

            var hub = new ChatHub
            {
                Clients = mockClients.Object,
                Context = mockContext.Object
            };

            string user = "enoque";
            string message = "probando mensaje";

            // Act
            await hub.SendMessage(user, message);

            // Assert
            mockClientProxy.Verify(client =>
                client.SendCoreAsync("ReceiveMessage",
                                     It.Is<object[]>(args => args.Length == 2 && 
                                                             (string)args[0] == user &&
                                                             (string)args[1] == message),
                                     default),
                Times.Once);
        }
    }
}
