// CQRS/Commands/CreateFeedbackCommand.cs
using FastEndpoints;
using FeedbackService.Models;

namespace FeedbackService.CQRS.Commands;

public class CreateFeedbackCommand : ICommand<Feedback>
{
    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;
    public Guid UserId { get; set; }
}
