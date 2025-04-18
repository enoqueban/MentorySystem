// CQRS/Handlers/GetFeedbackByIdHandler.cs
using FeedbackService.CQRS.Queries;
using FeedbackService.Data;
using FeedbackService.Models;
using FastEndpoints;

namespace FeedbackService.CQRS.Handlers;

public class GetFeedbackByIdHandler : CommandHandler<GetFeedbackByIdQuery, Feedback>
{
    private readonly FeedbackDbContext _db;

    public GetFeedbackByIdHandler(FeedbackDbContext db)
    {
        _db = db;
    }

    public override async Task<Feedback> ExecuteAsync(GetFeedbackByIdQuery cmd, CancellationToken ct)
    {
        return await _db.Feedbacks.FindAsync(new object[] { cmd.FeedbackId }, ct)
            ?? throw new Exception("Feedback not found");
    }
}
