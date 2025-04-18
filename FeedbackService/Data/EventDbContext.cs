using Microsoft.EntityFrameworkCore;
using FeedbackService.Models;

namespace FeedbackService.Data;

public class EventDbContext : DbContext
{
    public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }

    public DbSet<Feedback> Feedbacks => Set<Feedback>();
    public DbSet<FeedbackEvent> FeedbackEvents => Set<FeedbackEvent>();
}