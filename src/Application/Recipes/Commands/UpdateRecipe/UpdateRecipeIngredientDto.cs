namespace Application.Recipes.Commands.CreateRecipe;
public class UpdateRecipeIngredientDto
{
    public Guid? Id { get; set; }
    public Guid IngredientId { get; set; }
    public float Amount { get; set; }
}
