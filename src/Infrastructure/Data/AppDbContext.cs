﻿using Domain.Entities;
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
        modelBuilder.Entity<Recipe>().HasMany(r => r.Ingredients).WithOne(ri => ri.Recipe).HasForeignKey(ri => ri.RecipeId).OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<Recipe>? Recipes { get; set; }
    public DbSet<Instruction>? Instructions { get; set; }
    public DbSet<Ingredient>? Ingredients { get; set; }
    public DbSet<RecipeIngredient>? RecipeIngredients { get; set; }
}
