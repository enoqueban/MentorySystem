using StackExchange.Redis;
namespace NotificationService.Data
{
    public class RedisCache : IRedisCache
    {
        private readonly IDatabase _database;

        public RedisCache()
        {
            var connection = ConnectionMultiplexer.Connect("localhost");
            _database = connection.GetDatabase();
        }

        public void StoreNotification(string message)
        {
            _database.ListLeftPush("notifications", message);
        }
    }
}
