using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace deathmatch_micro.Domain;

public abstract class BaseEntity
{
    [Key, Required]
    public required Guid Id { get; set; }
}
