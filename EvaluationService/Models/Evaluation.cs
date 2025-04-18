namespace EvaluationService.Models;

public class Evaluation
{
    public Guid Id { get; set; }
    public Guid EvaluatorUserId { get; set; }
    public Guid EvaluatedUserId { get; set; }
    public Guid MentorId { get; set; } // Asumido que es importante en los filtros
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Comments { get; set; }
    public int Score { get; set; }
    public DateTime CreatedAt { get; set; }
}
