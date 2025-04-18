// CQRS/Commands/DeleteFeedbackCommand.cs
using FastEndpoints;

namespace FeedbackService.CQRS.Commands;

public class DeleteFeedbackCommand : ICommand<bool>
{
    public Guid FeedbackId { get; set; }
}
