using EvaluationService.CQRS.Queries;
using EvaluationService.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace EvaluationService.CQRS.Handlers;

public class GetEvaluationByIdHandler : Endpoint<GetEvaluationByIdQuery, object>
{
    private readonly EventDbContext _db;

    public GetEvaluationByIdHandler(EventDbContext db)
    {
        _db = db;
    }

    public override void Configure()
    {
        Get("/api/evaluations/{EvaluationId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetEvaluationByIdQuery req, CancellationToken ct)
    {
        var evaluation = await _db.Evaluations
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == req.EvaluationId, ct);

        if (evaluation is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(evaluation, ct);
    }
}
