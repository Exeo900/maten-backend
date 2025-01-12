using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>().HasMany(x => x.Instructions).WithOne(x => x.Recipe).OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<Recipe>? Recipes { get; set; }
    public DbSet<Instruction>? Instructions { get; set; }
}
