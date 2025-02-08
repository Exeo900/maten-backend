using Domain.Entities;

namespace Application.Recipes.Common.Interfaces;
public interface IRecipeService : IRepositoryService<Recipe>
{
    Task RemoveRecipeIngredients(IEnumerable<RecipeIngredient> ingredients);
    Task RemoveRecipeInstructions(IEnumerable<Instruction> ingredients);
}