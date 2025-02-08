using Application.Recipes.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.Commands.CreateRecipe;
public class UpdateIngredientCommandHandler : IRequestHandler<UpdateIngredientCommand, Guid>
{
    private readonly IRepositoryService<Ingredient> _repositoryService;

    public UpdateIngredientCommandHandler(IRepositoryService<Ingredient> repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public async Task<Guid> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingredient = await _repositoryService.GetById(request.Id);

        ingredient.Name = request.Name;
        ingredient.Description = request.Description; 

        await _repositoryService.Update(ingredient);

        return ingredient.Id;
    }
}
