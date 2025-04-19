using MentoringSystem.Shared.Messaging;
using NotificationService.Data;

namespace NotificationService.Services
{
    public class NotificationProcessor
    {
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IRedisCache _redisCache;

        public NotificationProcessor(IRabbitMQService rabbitMQService, IRedisCache redisCache)
        {
            _rabbitMQService = rabbitMQService;
            _redisCache = redisCache;
        }

        public void PublishNotification(string message)
        {
            _rabbitMQService.Publish("notifications", message);
        }

        private void ProcessNotification(string message)
        {
            _redisCache.StoreNotification(message);
        }
    }
}
