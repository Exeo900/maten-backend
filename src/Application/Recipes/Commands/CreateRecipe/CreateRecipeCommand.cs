using MediatR;

namespace Application.Recipes.Commands.CreateRecipe;
public class CreateRecipeCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public IEnumerable<CreateInstructionDto>? Instructions { get; set; }
    public IEnumerable<CreateRecipeIngredientDto>? Ingredients { get; set; }
}
