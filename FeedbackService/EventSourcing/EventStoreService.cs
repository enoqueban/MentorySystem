// EventSourcing/EventStoreService.cs
namespace FeedbackService.EventSourcing;

public class EventStoreService<T> where T : class
{
    private readonly List<T> _eventStore = new();

    public Task StoreAsync(T @event)
    {
        _eventStore.Add(@event);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult(_eventStore.AsEnumerable());
    }
}
