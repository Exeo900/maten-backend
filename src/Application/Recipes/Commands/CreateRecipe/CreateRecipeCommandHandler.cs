using Application.Recipes.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.Commands.CreateRecipe;
public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Guid>
{
    private readonly IRepositoryService<Recipe> _repositoryService;

    public CreateRecipeCommandHandler(IRepositoryService<Recipe> repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public async Task<Guid> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var instructions = request.Instructions?.Select(x => new Instruction
        {
            StepNumber = x.StepNumber,
            Text = x.Text
        }).ToList();

        var ingredients = request.Ingredients?.Select(x => new RecipeIngredient
        {
            Amount = x.Amount,
            IngredientId = x.IngredientId
        }).ToList();

        var recipe = new Recipe
        {
            Name = request.Name,
            Instructions = instructions ?? new List<Instruction>(),
            Ingredients = ingredients ?? new List<RecipeIngredient>()
        };

        await _repositoryService.Create(recipe);

        return recipe.Id;
    }
}