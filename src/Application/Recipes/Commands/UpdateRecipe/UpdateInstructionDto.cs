namespace Application.Recipes.Commands.CreateRecipe;
public class UpdateInstructionDto
{
    public Guid? Id { get; set; }
    public required string Text { get; set; }
    public int StepNumber { get; set; }
}
