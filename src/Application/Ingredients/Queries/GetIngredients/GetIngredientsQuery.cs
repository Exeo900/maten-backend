using MediatR;

namespace Application.Recipes.Queries.GetRecipes;
public record GetIngredientsQuery : IRequest<IngredientsVm>
{
}
