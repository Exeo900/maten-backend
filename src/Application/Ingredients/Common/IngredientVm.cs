namespace Application.Recipes.Common.Models
{
    public class IngredientVm
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }         
        public string? Description { get; set; }
    }
}
