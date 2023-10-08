using GetPostsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GetPostsApp.Infrastructure
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<Record> Records { get; set; } 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Record>()
        .Property(e => e.Id)
        .ValueGeneratedOnAdd();

      base.OnModelCreating(modelBuilder);
    }
  }
}
