using deathmatch_micro.Application.TodoLists.Queries.ExportTodos;

namespace deathmatch_micro.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
