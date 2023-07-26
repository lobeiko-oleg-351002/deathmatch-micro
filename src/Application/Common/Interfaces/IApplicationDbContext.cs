using deathmatch_micro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace deathmatch_micro.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
