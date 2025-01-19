using MediatR;

namespace Application.Recipes.Commands.CreateRecipe;
public class DeleteIngredientCommand : IRequest<int>
{
    public required Guid Id { get; set; }
}
