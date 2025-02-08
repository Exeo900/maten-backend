namespace Application.Recipes.Common.Models;
public class RecipeIngredientVm
{
    public Guid Id { get; set; }
    public Guid? IngredientId { get; set; }
    public float Amount { get; set; }
}
