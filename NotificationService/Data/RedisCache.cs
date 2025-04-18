using StackExchange.Redis;

namespace NotificationService.Data
{
    public class RedisCache
    {
        private readonly ConnectionMultiplexer _redis;

        public RedisCache(IConfiguration configuration)
        {
            var redisConnectionString = configuration.GetConnectionString("Redis");
            _redis = ConnectionMultiplexer.Connect(redisConnectionString);
        }

        public void StoreNotification(string notification)
        {
            var db = _redis.GetDatabase();
            db.StringSet($"notification:{Guid.NewGuid()}", notification, TimeSpan.FromMinutes(5));
        }
    }
}
