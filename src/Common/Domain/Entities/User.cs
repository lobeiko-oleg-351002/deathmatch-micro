using System.ComponentModel.DataAnnotations;

namespace deathmatch_micro.Domain.Entities;

public class User : BaseEntity
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }

    [Required]
    public virtual required Role Role { get; set; }
}
