using System.Globalization;
using deathmatch_micro.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace deathmatch_micro.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).Convert(c => c.Value.Done ? "Yes" : "No");
    }
}
