namespace FeedbackService.Models;

public class FeedbackModelEvent
{
    public Guid   FeedbackId { get; init; } 
    public string EventType { get; set; } = string.Empty;
    public Feedback Payload { get; set; } = null!;
    public DateTime Timestamp { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = default!;

}
