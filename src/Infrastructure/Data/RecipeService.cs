using Application.Recipes.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class RecipeService : RepositoryService<Recipe>, IRecipeService
{
    private readonly AppDbContext _context;
    protected readonly DbSet<Recipe> _dbSet;

    public RecipeService(AppDbContext context) : base(context)
    {
        _context = context;
        _dbSet = _context.Set<Recipe>();
    }

    public async Task RemoveRecipeIngredients(IEnumerable<RecipeIngredient> ingredients)
    {
        _context.RecipeIngredients.RemoveRange(ingredients);

        await _context.SaveChangesAsync();
    }

    public async Task RemoveRecipeInstructions(IEnumerable<Instruction> ingredients)
    {
        _context.Instructions.RemoveRange(ingredients);

        await _context.SaveChangesAsync();
    }
}
