using Core.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Database;

public class SpireonDbContext : DbContext
{
    public SpireonDbContext(DbContextOptions<SpireonDbContext> options) : base(options)
    {

    }

    // Database Tables
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure User Entity
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            // Soft delete filter - hide deleted records automatically
            entity.HasQueryFilter(e => e.DeletedAt == null);

            // Index for faster email lookups
            entity.HasIndex(e => e.Email).IsUnique();
        });
    }
}
