using Application.Recipes.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.Commands.CreateRecipe;
public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, Guid>
{
    private readonly IRecipeService _recipeService;

    public UpdateRecipeCommandHandler(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    public async Task<Guid> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var recipe = await _recipeService.GetById(request.Id, r => r.Instructions, r => r.Ingredients);

        if (recipe == null)
        {
            throw new KeyNotFoundException($"Recipe with ID {request.Id} not found.");
        }

        recipe.Name = request.Name;

        // TODO: Fix so we dont always remove related entities, only remove entities not found in the request.

        await _recipeService.RemoveRecipeInstructions(recipe.Instructions);
        recipe.Instructions = MapInstructions(request.Instructions, recipe);

        await _recipeService.RemoveRecipeIngredients(recipe.Ingredients);
        recipe.Ingredients = MapRecipeIngredients(request.Ingredients, recipe);

        await _recipeService.Update(recipe);

        return recipe.Id;
    }

    private List<Instruction> MapInstructions(IEnumerable<UpdateInstructionDto>? instructions, Recipe recipe)
    {
        if (instructions == null)
        {
            return new List<Instruction>();
        }

        return instructions?.Select(x => new Instruction
        {
            StepNumber = x.StepNumber,
            Text = x.Text,
            Recipe = recipe
        }).ToList() ?? new List<Instruction>();
    }

    private List<RecipeIngredient> MapRecipeIngredients(IEnumerable<UpdateRecipeIngredientDto>? ingredients, Recipe recipe)
    {
        if (ingredients == null)
        {
            return new List<RecipeIngredient>();
        }

        return ingredients?.Select(x => new RecipeIngredient
        {
            Amount = x.Amount,
            IngredientId = x.IngredientId,
            RecipeId = recipe.Id,
            Recipe = recipe
        }).ToList() ?? new List<RecipeIngredient>();
    }
}

