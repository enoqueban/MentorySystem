using FeedbackService.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Data;

public class FeedbackDbContext : DbContext
{
    public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options) { }

    public DbSet<Feedback> Feedbacks => Set<Feedback>();
}
