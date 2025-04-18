using EvaluationService.CQRS.Queries;
using EvaluationService.Data;
using EvaluationService.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace EvaluationService.CQRS.Handlers;

public class GetEvaluationsByMentorHandler : Endpoint<GetEvaluationsByMentorQuery, List<Evaluation>>
{
    private readonly EventDbContext _db;

    public GetEvaluationsByMentorHandler(EventDbContext db)
    {
        _db = db;
    }

    public override void Configure()
    {
        Get("/api/evaluations/mentor/{MentorId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetEvaluationsByMentorQuery req, CancellationToken ct)
    {
        var evaluations = await _db.Evaluations
            .Where(e => e.MentorId == req.MentorId)
            .AsNoTracking()
            .ToListAsync(ct);

        await SendOkAsync(evaluations, ct);
    }
}
