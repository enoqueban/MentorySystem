using FastEndpoints;
using PriorityService.CQRS.Commands;
using PriorityService.Data;

namespace PriorityService.CQRS.Handlers;

public class CreatePriorityHandler : Endpoint<CreatePriorityCommand>
{
    private readonly DapperRepository _repository;

    public CreatePriorityHandler(DapperRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Post("/api/priorities");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePriorityCommand req, CancellationToken ct)
    {
        await _repository.CreatePriorityAsync(req.Title, req.Description, req.DueDate);
        await SendAsync(new { message = "Priority created successfully!" }, cancellation: ct);
    }
}
