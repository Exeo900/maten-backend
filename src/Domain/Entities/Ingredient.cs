namespace Domain.Entities;
public class Ingredient : Entity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}
