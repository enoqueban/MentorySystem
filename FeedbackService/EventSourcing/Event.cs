namespace FeedbackService.EventSourcing;

public abstract class Event
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
}
