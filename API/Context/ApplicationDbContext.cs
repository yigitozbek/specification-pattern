using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API.Context;

/// <summary>
///     The application database context.
/// </summary>
/// <param name="configuration"></param>
public class ApplicationDbContext(IConfiguration configuration) : DbContext
{
    /// <summary>
    ///     The application database context.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));

        optionsBuilder
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    /// <summary>
    ///     The tasks.
    /// </summary>
    public DbSet<API.Entities.Task> Tasks { get; set; }
}