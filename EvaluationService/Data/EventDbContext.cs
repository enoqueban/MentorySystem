// DbContext or document DB context depending on implementationusing Microsoft.EntityFrameworkCore;
using EvaluationService.Models;
using Microsoft.EntityFrameworkCore;

namespace EvaluationService.Data;

public class EventDbContext : DbContext
{
    public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }

    public DbSet<Evaluation> Evaluations => Set<Evaluation>();
    public DbSet<EvaluationEvent> Events => Set<EvaluationEvent>();
}
