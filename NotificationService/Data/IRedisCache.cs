namespace NotificationService.Data
{
    public interface IRedisCache
    {
        void StoreNotification(string message);
    }
}