using Application.Recipes.Common.Interfaces;
using Application.Recipes.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.Queries.GetRecipes;
public class GetRecipesHandler : IRequestHandler<GetRecipeQuery, RecipesVm>
{
    private readonly IRepositoryService<Recipe> _repositoryService;

    public GetRecipesHandler(IRepositoryService<Recipe> repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public async Task<RecipesVm> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
    {
       var allRecipes = await _repositoryService.GetAll(x => x.Instructions, x => x.Ingredients);

       return new RecipesVm() { 
           Recipes = allRecipes.Select(x => new RecipeVm() 
           { 
               Id = x.Id, 
               Name = x.Name,
               Instructions = x.Instructions?.Select(y => new InstructionVm()
               {
                   Id = y.Id,
                   Text = y.Text,
                   StepNumber = y.StepNumber,
               }),
               RecipeIngredients = x.Ingredients?.Select(y => new RecipeIngredientVm()
               {
                   Id = y.Id,
                   Amount = y.Amount,
                   IngredientId = y.IngredientId
               })
           }) 
       };
    }
}
