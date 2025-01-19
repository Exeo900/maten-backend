using Application.Recipes.Commands.CreateRecipe;
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
            app.MapPost("/recipes", CreateRecipe);
            app.MapDelete("/recipes", DeleteRecipe);

            app.MapGet("/ingredients", GetIngrediens);
            app.MapPost("/ingredients", CreateIngredient);
            app.MapDelete("/ingredients", DeleteIngredient);
        }

        public static async Task<Ok<RecipesVm>> GetRecipes(ISender sender)
        {
            var vm = await sender.Send(new GetRecipeQuery());

            return TypedResults.Ok(vm);
        }

        public static async Task<Ok<Guid>> CreateRecipe(ISender sender, CreateRecipeCommand createRecipeCommand)
        {
            var vm = await sender.Send(createRecipeCommand);

            return TypedResults.Ok(vm);
        }

        public static async Task<Ok<int>> DeleteRecipe(ISender sender, Guid id)
        {
            var vm = await sender.Send(new DeleteRecipeCommand() { Id = id });

            return TypedResults.Ok(vm);
        }

        public static async Task<Ok<IngredientsVm>> GetIngrediens(ISender sender)
        {
            var vm = await sender.Send(new GetIngredientsQuery());

            return TypedResults.Ok(vm);
        }

        public static async Task<Ok<Guid>> CreateIngredient(ISender sender, CreateIngredientCommand createIngredientCommand)
        {
            var vm = await sender.Send(createIngredientCommand);

            return TypedResults.Ok(vm);
        }

        public static async Task<Ok<int>> DeleteIngredient(ISender sender, Guid id)
        {
            var vm = await sender.Send(new DeleteIngredientCommand() { Id = id });

            return TypedResults.Ok(vm);
        }
    }
}
