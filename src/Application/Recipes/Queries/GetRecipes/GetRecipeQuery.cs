using MediatR;

namespace Application.Recipes.Queries.GetRecipes;
public record GetRecipeQuery : IRequest<RecipesVm>
{
}
