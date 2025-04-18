namespace PriorityService.CQRS.Commands;

public class CreatePriorityCommand
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
}
