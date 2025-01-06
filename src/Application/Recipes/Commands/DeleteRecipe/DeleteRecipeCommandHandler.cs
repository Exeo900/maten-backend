using Application.Recipes.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.Commands.CreateRecipe;
public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, int>
{
    private readonly IRepositoryService<Recipe> _repositoryService;

    public DeleteRecipeCommandHandler(IRepositoryService<Recipe> repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public async Task<int> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = await _repositoryService.GetById(request.Id);

        return await _repositoryService.Delete(recipe);
    }
}
