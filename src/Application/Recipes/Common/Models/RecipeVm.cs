namespace Application.Recipes.Common.Models
{
    public class RecipeVm
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }    
        public IEnumerable<InstructionVm>? Instructions { get; set; }
    }
}
