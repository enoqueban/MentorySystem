using FluentAssertions;
using Moq;
using Xunit;

using NotificationProcessor = NotificationService.Services.NotificationProcessor;
using RedisCache = NotificationService.Data.RedisCache;
using MentoringSystem.Shared.Messaging;

namespace NotificationService.Tests
{
    public class NotificationProcessorTests
    {
        [Fact]
        public void PublishNotification_ShouldCallRabbitMQServicePublish()
        {
            var mockRabbit = new Mock<RabbitMQService>(null!);
            var mockRedis = new Mock<RedisCache>(null!);
            var processor = new NotificationProcessor(mockRabbit.Object, mockRedis.Object);

            var message = "Hello World";

            processor.PublishNotification(message);

            mockRabbit.Verify(x => x.Publish("notifications", message), Times.Once);
        }

        [Fact]
        public void ProcessNotification_ShouldCallRedisStore()
        {
            var mockRabbit = new Mock<RabbitMQService>(null!);
            var mockRedis = new Mock<RedisCache>(null!);
            var processor = new NotificationProcessor(mockRabbit.Object, mockRedis.Object);

            var message = "Test Message";

            processor.GetType()
                     .GetMethod("ProcessNotification", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                     .Invoke(processor, new object[] { message });

            mockRedis.Verify(x => x.StoreNotification(message), Times.Once);
        }
    }
}
