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
       var allRecipes = await _repositoryService.GetAll(includes: x => x.Instructions);

       return new RecipesVm() { 
           Recipes = allRecipes.Select(x => new RecipeVm() 
           { 
               Id = x.Id, 
               Name = x.Name,
               Instructions = x.Instructions?.Select(x => new InstructionVm()
               {
                   Id = x.Id,
                   Text = x.Text,
                   StepNumber = x.StepNumber,
               })
           }) 
       };
    }
}
