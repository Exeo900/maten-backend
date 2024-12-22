using Application.Recipes.Common.Models;

namespace Application.Recipes.Queries.GetRecipes
{
    public class RecipesVm
    {
        public required IEnumerable<RecipeVm> Recipes { get; set; }
    }
}
