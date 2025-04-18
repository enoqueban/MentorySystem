// CQRS/Handlers/DeleteFeedbackHandler.cs
using FeedbackService.CQRS.Commands;
using FeedbackService.Data;
using FastEndpoints;

namespace FeedbackService.CQRS.Handlers;

public class DeleteFeedbackHandler : CommandHandler<DeleteFeedbackCommand, bool>
{
    private readonly FeedbackDbContext _db;

    public DeleteFeedbackHandler(FeedbackDbContext db)
    {
        _db = db;
    }

    public override async Task<bool> ExecuteAsync(DeleteFeedbackCommand cmd, CancellationToken ct)
    {
        var feedback = await _db.Feedbacks.FindAsync(new object[] { cmd.FeedbackId }, ct);
        if (feedback is null)
            return false;

        _db.Feedbacks.Remove(feedback);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
