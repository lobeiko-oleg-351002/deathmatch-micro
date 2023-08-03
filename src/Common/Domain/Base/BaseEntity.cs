using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace deathmatch_micro.Domain;

public abstract class BaseEntity
{
    [Key, Required]
    public Guid Id { get; set; }
}
