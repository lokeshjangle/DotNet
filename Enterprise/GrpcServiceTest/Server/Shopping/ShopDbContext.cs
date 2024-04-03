using Microsoft.EntityFrameworkCore;

namespace DemoApp.Shopping;

public class ShopDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    public DbSet<Counter> Counters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=iitdac.met.edu;Database=Shop1;User ID=dac1;Password=Dac1@1234;Encrypt=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .ToTable("OrderDetail")
            .Property(p => p.Id)
            .HasColumnName("OrderNo");
    }
}
