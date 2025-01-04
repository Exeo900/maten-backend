using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Entity
{
    [Key]
    public Guid Id { get; init; }
}
