using Application.Recipes.Commands.CreateRecipe;
using Application.Recipes.Queries.GetRecipes;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace maten_backend.Endpoints;

public static class IngredientEndpoints
{
    public static void RegisterIngredientEndpoints(this WebApplication app)
    {
        app.MapGet("/ingredients", GetIngrediens);
        app.MapPost("/ingredients", CreateIngredient);
        app.MapPut("/ingredients", UpdateIngredient);
        app.MapDelete("/ingredients", DeleteIngredient);
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

    public static async Task<Ok<Guid>> UpdateIngredient(ISender sender, UpdateIngredientCommand updateIngredientCommand)
    {
        var vm = await sender.Send(updateIngredientCommand);

        return TypedResults.Ok(vm);
    }

    public static async Task<Ok<int>> DeleteIngredient(ISender sender, Guid id)
    {
        var vm = await sender.Send(new DeleteIngredientCommand() { Id = id });

        return TypedResults.Ok(vm);
    }
}
