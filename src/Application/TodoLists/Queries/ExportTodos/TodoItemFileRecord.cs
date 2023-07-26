using deathmatch_micro.Application.Common.Mappings;
using deathmatch_micro.Domain.Entities;

namespace deathmatch_micro.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; init; }

    public bool Done { get; init; }
}
