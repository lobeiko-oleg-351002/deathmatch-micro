using deathmatch_micro.Application.Common.Mappings;
using deathmatch_micro.Domain.Entities;

namespace deathmatch_micro.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<TodoList>, IMapFrom<TodoItem>
{
    public int Id { get; init; }

    public string? Title { get; init; }
}
