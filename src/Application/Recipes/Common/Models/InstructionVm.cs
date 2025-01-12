namespace Application.Recipes.Common.Models
{
    public class InstructionVm
    {
        public required Guid Id { get; set; }
        public int StepNumber { get; set; }
        public required string Text { get; set; }    
    }
}
