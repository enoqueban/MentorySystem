namespace EvaluationService.CQRS.Commands;

public class CreateEvaluationCommand
{
    public Guid EvaluatorUserId { get; set; }
    public Guid EvaluatedUserId { get; set; }
    public Guid MentorId { get; set; } // si no aplica, lo quitamos luego
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Comments { get; set; }
    public int Score { get; set; }
}
