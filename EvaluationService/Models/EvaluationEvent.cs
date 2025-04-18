namespace EvaluationService.Models;

public class EvaluationEvent
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public int Score { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
