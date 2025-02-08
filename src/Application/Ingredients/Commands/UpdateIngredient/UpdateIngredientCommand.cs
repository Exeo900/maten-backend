using MediatR;

namespace Application.Recipes.Commands.CreateRecipe;
public class UpdateIngredientCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
