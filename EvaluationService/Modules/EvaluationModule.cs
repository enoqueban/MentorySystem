using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using EvaluationService.Data;

namespace EvaluationService.Modules;

public class EvaluationModule : EndpointWithoutRequest
{
    private readonly EventDbContext _context;

    public EvaluationModule(EventDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/api/evaluations");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var evaluations = await _context.Evaluations.ToListAsync(ct);
        await SendOkAsync(evaluations, ct);
    }
}
