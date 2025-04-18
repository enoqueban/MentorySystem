using MentoringSystem.Shared.Messaging;
using NotificationService.Data;

namespace NotificationService.Services
{
    public class NotificationProcessor
    {
        private readonly RabbitMQService _rabbitMQService;
        private readonly RedisCache _redisCache;

        public NotificationProcessor(RabbitMQService rabbitMQService, RedisCache redisCache)
        {
            _rabbitMQService = rabbitMQService;
            _redisCache = redisCache;
        }

        public void StartProcessing()
        {
            _rabbitMQService.Subscribe<string>("notifications", ProcessNotification);
        }

        private void ProcessNotification(string message)
        {
            _redisCache.StoreNotification(message);
        }

        public void PublishNotification(string message)
        {
            _rabbitMQService.Publish("notifications", message);
        }
    }
}
