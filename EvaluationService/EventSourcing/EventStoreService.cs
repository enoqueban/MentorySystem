namespace EvaluationService.EventSourcing;

public class EventStoreService<TEvent>
{
    private readonly List<TEvent> _events = new();

    public void AddEvent(TEvent @event)
    {
        _events.Add(@event);
    }

    public IReadOnlyList<TEvent> GetEvents() => _events.AsReadOnly();
}
