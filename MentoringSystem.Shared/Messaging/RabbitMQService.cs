using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MentoringSystem.Shared.Messaging
{
    public class RabbitMQService : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService(IConfiguration configuration)
        {
            var factory = new ConnectionFactory()
            {
                HostName = configuration["RabbitMQ:HostName"],
                UserName = configuration["RabbitMQ:UserName"],
                Password = configuration["RabbitMQ:Password"],
                VirtualHost = configuration["RabbitMQ:VirtualHost"] ?? "/"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void DeclareQueue(string queueName)
        {
            _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false);
        }

        public void Publish<T>(string queueName, T message)
        {
            DeclareQueue(queueName);
            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);
            var props = _channel.CreateBasicProperties();
            props.Persistent = true;
            _channel.BasicPublish("", queueName, props, body);
        }

        public void Subscribe<T>(string queueName, Action<T> onMessage)
        {
            DeclareQueue(queueName);
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);
                T msg = JsonSerializer.Deserialize<T>(json)!;
                onMessage(msg);
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume(queueName, false, consumer);
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
