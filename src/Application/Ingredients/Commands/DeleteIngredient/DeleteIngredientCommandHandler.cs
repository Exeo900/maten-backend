using Application.Recipes.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.Commands.CreateRecipe;
public class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand, int>
{
    private readonly IRepositoryService<Ingredient> _repositoryService;

    public DeleteIngredientCommandHandler(IRepositoryService<Ingredient> repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public async Task<int> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
    {
        var recipe = await _repositoryService.GetById(request.Id);

        return await _repositoryService.Delete(recipe);
    }
}
