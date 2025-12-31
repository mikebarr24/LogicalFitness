using LogicalFitness.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LogicalFitness.Infrastructure.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions options) : base(options)
  {

  }

  public DbSet<User> Users => Set<User>();
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>()
      .HasIndex(u => u.Email)
      .IsUnique();
  }
}
