using Application.Recipes.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.Commands.CreateRecipe;
public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, Guid>
{
    private readonly IRepositoryService<Ingredient> _repositoryService;

    public CreateIngredientCommandHandler(IRepositoryService<Ingredient> repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public async Task<Guid> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingredient = new Ingredient { Name = request.Name, Description = request.Description };

        await _repositoryService.Create(ingredient);

        return ingredient.Id;
    }
}
