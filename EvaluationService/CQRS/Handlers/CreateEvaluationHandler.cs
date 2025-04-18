using EvaluationService.CQRS.Commands;
using EvaluationService.Data;
using EvaluationService.Models;
using FastEndpoints;

namespace EvaluationService.CQRS.Handlers;

public class CreateEvaluationHandler : Endpoint<CreateEvaluationCommand, string>
{
    private readonly EventDbContext _db;

    public CreateEvaluationHandler(EventDbContext db)
    {
        _db = db;
    }

    public override void Configure()
    {
        Post("/api/evaluations");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateEvaluationCommand req, CancellationToken ct)
    {
        var evaluation = new Evaluation
        {
            Id = Guid.NewGuid(),
            //UserId = req.UserId,
            MentorId = req.MentorId,
            Comments = req.Comments,
            Score = req.Score,
            CreatedAt = DateTime.UtcNow
        };

        _db.Evaluations.Add(evaluation);
        await _db.SaveChangesAsync(ct);

        await SendAsync("Evaluation created successfully", 201, ct);
    }
}
