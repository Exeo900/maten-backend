using Application.Recipes.Common.Models;
using Application.Recipes.Queries.GetRecipes;
using Microsoft.AspNetCore.Http.HttpResults;

namespace maten_backend.Endpoints
{
    public static class Endpoints
    {
        public static void ConfigureEndpoints(this WebApplication app)
        {
            app.MapGet("/recipes", GetRecipe);
        }

        public static async Task<Ok<RecipesVm>> GetRecipe()
        {
            var recipes = new RecipesVm()
            {
                Recipes = new List<RecipeVm>()
                {
                    new RecipeVm()
                    {
                        Name = "Korvstroganoff"
                    }
                }
            };

            return TypedResults.Ok(recipes);
        }
    }
}
