using Application.Recipes.Common.Interfaces;
using Application.Recipes.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.Queries.GetRecipes;
public class GetIngredientsHandler : IRequestHandler<GetIngredientsQuery, IngredientsVm>
{
    private readonly IRepositoryService<Ingredient> _repositoryService;

    public GetIngredientsHandler(IRepositoryService<Ingredient> repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public async Task<IngredientsVm> Handle(GetIngredientsQuery request, CancellationToken cancellationToken)
    {
       var allIngredients = await _repositoryService.GetAll();

       return new IngredientsVm() { 
           Ingredients = allIngredients.Select(x => new IngredientVm()
           {
               Id = x.Id,
               Name = x.Name,
               Description = x.Description,
           }).ToList()
       };
    }
}
