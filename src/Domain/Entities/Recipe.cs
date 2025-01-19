namespace Domain.Entities;
public class Recipe : Entity
{
    public required string Name { get; set; }
    public IEnumerable<Instruction> Instructions { get; set; } = new List<Instruction>();
    public ICollection<RecipeIngredient> Ingredients { get; set; } = new List<RecipeIngredient>();
}
