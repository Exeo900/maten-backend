namespace Domain.Entities;
public class Instruction : Entity
{
    public int StepNumber { get; set; }
    public required string Text { get; set; }
}
