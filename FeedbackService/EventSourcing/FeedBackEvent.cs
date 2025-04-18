using FeedbackService.Models;
namespace FeedbackService.EventSourcing;
public class FeedbackEvent : Event
{
    public Feedback Feedback { get; set; } = default!;
}
