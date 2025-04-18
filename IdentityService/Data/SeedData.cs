using IdentityService.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

        if (context.Users.Any()) return;

        context.Users.Add(new User
        {
            FullName = "Admin Root",
            Email = "admin@mentoring.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
            Role = "Administrator"
        });

        context.SaveChanges();
    }
}
