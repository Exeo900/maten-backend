using MediatR;

namespace Application.Recipes.Commands.CreateRecipe;
public class CreateIngredientCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}
