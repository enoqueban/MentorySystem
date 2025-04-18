// CQRS/Handlers/GetAllFeedbackHandler.cs
using FeedbackService.CQRS.Queries;
using FeedbackService.Data;
using FeedbackService.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.CQRS.Handlers;

public class GetAllFeedbackHandler : CommandHandler<GetAllFeedbackQuery, List<Feedback>>
{
    private readonly FeedbackDbContext _db;

    public GetAllFeedbackHandler(FeedbackDbContext db)
    {
        _db = db;
    }

    public override async Task<List<Feedback>> ExecuteAsync(GetAllFeedbackQuery cmd, CancellationToken ct)
    {
        return await _db.Feedbacks.AsNoTracking().ToListAsync(ct);
    }
}
