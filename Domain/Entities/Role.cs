using System.ComponentModel.DataAnnotations;
using deathmatch_micro.Domain;

namespace deathmatch_micro.Domain.Entities;

public class Role : BaseEntity
{
    [Required]
    public required string Name { get; set; }
}
