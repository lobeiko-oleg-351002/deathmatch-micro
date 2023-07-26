using deathmatch_micro.Application.Common.Mappings;
using deathmatch_micro.Domain.Entities;

namespace deathmatch_micro.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}
