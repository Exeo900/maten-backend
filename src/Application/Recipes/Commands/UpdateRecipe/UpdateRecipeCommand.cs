using MediatR;

namespace Application.Recipes.Commands.CreateRecipe;
public class UpdateRecipeCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<UpdateInstructionDto>? Instructions { get; set; }
    public IEnumerable<UpdateRecipeIngredientDto>? Ingredients { get; set; }
}
