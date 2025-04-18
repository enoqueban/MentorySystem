using EvaluationService.CQRS.Commands;
using EvaluationService.Data;
using FastEndpoints;

namespace EvaluationService.CQRS.Handlers;

public class DeleteEvaluationHandler : Endpoint<DeleteEvaluationCommand, string>
{
    private readonly EventDbContext _db;

    public DeleteEvaluationHandler(EventDbContext db)
    {
        _db = db;
    }

    public override void Configure()
    {
        Delete("/api/evaluations/{EvaluationId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteEvaluationCommand req, CancellationToken ct)
    {
        var evaluation = await _db.Evaluations.FindAsync(new object[] { req.EvaluationId }, ct);
        if (evaluation is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        _db.Evaluations.Remove(evaluation);
        await _db.SaveChangesAsync(ct);

        await SendOkAsync(ct);
    }
}
