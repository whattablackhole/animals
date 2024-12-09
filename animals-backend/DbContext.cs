namespace Animals.Data;

using Animals.Models.Animals;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{

    public DbSet<Animal> Animals { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>()
            .HasDiscriminator<string>("Type")
            .HasValue<Cat>("cat")
            .HasValue<Dog>("dog");
    }
}