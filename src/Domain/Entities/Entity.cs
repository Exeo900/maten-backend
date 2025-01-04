using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Entity
{
    [Key]
    public required Guid Id { get; init; }
}
