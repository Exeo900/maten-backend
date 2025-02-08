using Application.Recipes.Commands.CreateRecipe;
using Application.Recipes.Queries.GetRecipes;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace maten_backend.Endpoints;

public static class RecipeEndpoints
{
    public static void RegisterRecipeEndpoints(this WebApplication app)
    {
        app.MapGet("/recipes", GetRecipes);
        app.MapPost("/recipes", CreateRecipe);
        app.MapPut("/recipes", UpdateRecipe);
        app.MapDelete("/recipes", DeleteRecipe);
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

    public static async Task<Ok<Guid>> UpdateRecipe(ISender sender, UpdateRecipeCommand updateRecipeCommand)
    {
        var vm = await sender.Send(updateRecipeCommand);

        return TypedResults.Ok(vm);
    }

    public static async Task<Ok<int>> DeleteRecipe(ISender sender, Guid id)
    {
        var vm = await sender.Send(new DeleteRecipeCommand() { Id = id });

        return TypedResults.Ok(vm);
    }
}
