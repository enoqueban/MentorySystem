using EvaluationService.CQRS.Commands;
using EvaluationService.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace EvaluationService.CQRS.Handlers;

public class UpdateEvaluationHandler : Endpoint<UpdateEvaluationCommand, string>
{
    private readonly EventDbContext _db;

    public UpdateEvaluationHandler(EventDbContext db)
    {
        _db = db;
    }

    public override void Configure()
    {
        Put("/api/evaluations");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateEvaluationCommand req, CancellationToken ct)
    {
        var evaluation = await _db.Evaluations.FindAsync(new object[] { req.EvaluationId }, ct);
        if (evaluation is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        evaluation.Comments = req.Comments;
        evaluation.Score = req.Score;

        await _db.SaveChangesAsync(ct);
        await SendOkAsync(ct);
    }
}
