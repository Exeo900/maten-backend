namespace Domain.Entities;
public class RecipeIngredient : Entity
{
    public float Amount { get; set; }
    public Guid? IngredientId { get; set; }
    public Guid? RecipeId { get; set; }
}
