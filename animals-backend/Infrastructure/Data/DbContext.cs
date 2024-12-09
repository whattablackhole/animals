namespace Animals.Infrastructure.Data;

using Animals.Models.Animals;
using Microsoft.EntityFrameworkCore;

public class AnimalsDbContext : DbContext
{

    public DbSet<Animal> Animals { get; set; } = null!;

    public AnimalsDbContext(DbContextOptions<AnimalsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>()
            .HasDiscriminator<string>("Type")
            .HasValue<Cat>("cat")
            .HasValue<Dog>("dog");
    }
}