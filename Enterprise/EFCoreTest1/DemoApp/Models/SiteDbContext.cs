global using Microsoft.EntityFrameworkCore;

namespace DemoApp.Models;

public class SiteDbContext : DbContext
{
    public DbSet<Visitor> Visitors { get; set; }

    public SiteDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=site.db");
    }
}