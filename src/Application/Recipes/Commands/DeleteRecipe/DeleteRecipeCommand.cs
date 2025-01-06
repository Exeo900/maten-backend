using MediatR;

namespace Application.Recipes.Commands.CreateRecipe;
public class DeleteRecipeCommand : IRequest<int>
{
    public required Guid Id { get; set; }
}
