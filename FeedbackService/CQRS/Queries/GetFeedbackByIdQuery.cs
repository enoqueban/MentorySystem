// CQRS/Queries/GetFeedbackByIdQuery.cs
using FastEndpoints;
using FeedbackService.Models;

namespace FeedbackService.CQRS.Queries;

public class GetFeedbackByIdQuery : ICommand<Feedback>
{
    public Guid FeedbackId { get; set; }
}
