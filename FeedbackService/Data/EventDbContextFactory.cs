using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using FeedbackService.Data;
using System.IO;

namespace FeedbackService.Data;

public class EventDbContextFactory : IDesignTimeDbContextFactory<EventDbContext>
{
    public EventDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EventDbContext>();
        optionsBuilder.UseSqlite("Data Source=feedback.db");
        return new EventDbContext(optionsBuilder.Options);
    }
}
