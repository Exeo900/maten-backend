using Application.Recipes.Common.Models;

namespace Application.Recipes.Queries.GetRecipes
{
    public class IngredientsVm
    {
        public required IEnumerable<IngredientVm> Ingredients { get; set; }
    }
}
