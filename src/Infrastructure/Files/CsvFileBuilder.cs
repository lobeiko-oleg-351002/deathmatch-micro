using System.Globalization;
using deathmatch_micro.Application.Common.Interfaces;
using deathmatch_micro.Application.TodoLists.Queries.ExportTodos;
using deathmatch_micro.Infrastructure.Files.Maps;
using CsvHelper;

namespace deathmatch_micro.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
