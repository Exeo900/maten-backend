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
        var recipe = new Recipe { Name = request.Name, Instructions = request.Instructions };

        await _repositoryService.Create(recipe);

        return recipe.Id;
    }
}
