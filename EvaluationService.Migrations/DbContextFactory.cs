using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using EvaluationService.Data;

namespace EvaluationService.Migrations;

public class DbContextFactory : IDesignTimeDbContextFactory<EventDbContext>
{
    public EventDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<EventDbContext>();
        optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));

        return new EventDbContext(optionsBuilder.Options);
    }
}
