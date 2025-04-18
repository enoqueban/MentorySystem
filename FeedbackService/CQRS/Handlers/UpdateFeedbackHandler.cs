// CQRS/Handlers/UpdateFeedbackHandler.cs
using FeedbackService.CQRS.Commands;
using FeedbackService.Data;
using FeedbackService.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.CQRS.Handlers;

public class UpdateFeedbackHandler : CommandHandler<UpdateFeedbackCommand, Feedback>
{
    private readonly FeedbackDbContext _db;

    public UpdateFeedbackHandler(FeedbackDbContext db)
    {
        _db = db;
    }

    public override async Task<Feedback> ExecuteAsync(UpdateFeedbackCommand cmd, CancellationToken ct)
    {
        var feedback = await _db.Feedbacks.FindAsync(new object[] { cmd.FeedbackId }, ct);
        if (feedback is null)
            throw new Exception("Feedback not found");

        feedback.Title = cmd.Title;
        feedback.Message = cmd.Message;

        await _db.SaveChangesAsync(ct);
        return feedback;
    }
}
