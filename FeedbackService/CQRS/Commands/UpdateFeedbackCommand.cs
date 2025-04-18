// CQRS/Commands/UpdateFeedbackCommand.cs
using FastEndpoints;
using FeedbackService.Models;

namespace FeedbackService.CQRS.Commands;

public class UpdateFeedbackCommand : ICommand<Feedback>
{
    public Guid FeedbackId { get; set; }
    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;
}
