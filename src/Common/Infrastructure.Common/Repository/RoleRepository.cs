using deathmatch_micro.Domain.Entities;
using deathmatch_micro.Domain.Interfaces;
using deathmatch_micro.Infrastructure.Common;
using Infrastructure.Common.Exceptions;
using Infrastructure.Common.Logging;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Repository;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context, ILogMessageManager<Role> logMessageManager) : base(context, logMessageManager)
    {

    }

    public async Task<Role> GetByName(string name)
    {
        _logMessageManager.LogCustomMessage("GetByName " + name);
        var entity = await _context.Roles.FirstOrDefaultAsync(e => e.Name == name);
        if (entity == null)
        {
            var ex = new ItemNotFoundException();
            _logMessageManager.LogFailure(ex.Message);
            throw ex;
        }
        _logMessageManager.LogSuccess();
        return entity;
    }
}
