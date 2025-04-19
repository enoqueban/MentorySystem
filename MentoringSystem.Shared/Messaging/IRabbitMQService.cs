namespace MentoringSystem.Shared.Messaging
{
    public interface IRabbitMQService
    {
        void Publish<T>(string queueName, T message);
        void Subscribe<T>(string queueName, Action<T> onMessage);
    }
}