using Application.Recipes.Common.Models;
using Application.Recipes.Queries.GetRecipes;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace maten_backend.Endpoints
{
    public static class Endpoints
    {
        public static void ConfigureEndpoints(this WebApplication app)
        {
            app.MapGet("/recipes", GetRecipes);
        }

        public static async Task<Ok<RecipesVm>> GetRecipes(ISender sender)
        {
            var vm = await sender.Send(new GetRecipeQuery());

            return TypedResults.Ok(vm);
        }
    }
}
