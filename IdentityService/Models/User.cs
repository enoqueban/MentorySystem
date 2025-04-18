namespace IdentityService.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string FullName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string PasswordHash { get; set; } = null!;
    
    public string Role { get; set; } = "Counselee"; // Default role
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
