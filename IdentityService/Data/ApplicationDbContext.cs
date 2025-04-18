using IdentityService.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Data;

// This class represents the database context for the IdentityService application.
// It inherits from DbContext and is used to interact with the database.
// The constructor takes DbContextOptions as a parameter, which is used to configure the context.
// The Users property represents the Users table in the database and is of type DbSet<User>.
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
}
