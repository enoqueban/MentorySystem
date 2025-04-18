namespace EvaluationService.CQRS.Commands;

public class UpdateEvaluationCommand
{
    public Guid EvaluationId { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Comments { get; set; } = default!;
    public int Score { get; set; }
}
