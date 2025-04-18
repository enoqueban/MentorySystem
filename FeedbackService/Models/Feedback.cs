public class Feedback
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime Timestamp { get; set; }

}
