// CQRS/Handlers/CreateFeedbackHandler.cs
using FeedbackService.EventSourcing; // 👈 Asegura que EventStoreService<> esté disponible
using FeedbackService.CQRS.Commands;
using FeedbackService.Data;
using FeedbackService.Models; // ✅ Usamos Feedback desde Models
using FastEndpoints;

// 🔁 Alias para evitar ambigüedad entre FeedbackEvent de Models y EventSourcing
using FeedbackEventModel = FeedbackService.Models.FeedbackModelEvent;

namespace FeedbackService.CQRS.Handlers;

public class CreateFeedbackHandler : CommandHandler<CreateFeedbackCommand, Feedback>
{
    private readonly FeedbackDbContext _db;
    private readonly EventStoreService<FeedbackEventModel> _eventStore;

    public CreateFeedbackHandler(FeedbackDbContext db, EventStoreService<FeedbackEventModel> eventStore)
    {
        _db = db;
        _eventStore = eventStore;
    }

    public override async Task<Feedback> ExecuteAsync(CreateFeedbackCommand cmd, CancellationToken ct)
    {
        var feedback = new Feedback
        {
            Id = Guid.NewGuid(),
            Title = cmd.Title,
            Message = cmd.Message,
            UserId = cmd.UserId,
            CreatedAt = DateTime.UtcNow
        };

        _db.Feedbacks.Add(feedback);
        await _db.SaveChangesAsync(ct);

        await _eventStore.StoreAsync(new FeedbackEventModel
        {
            FeedbackId = feedback.Id,
            Title = feedback.Title,
            Message = feedback.Message,
            Timestamp = feedback.CreatedAt
        });

        return feedback;
    }
}
