using deathmatch_micro.Domain.Entities;
using deathmatch_micro.Domain.Interfaces;
using deathmatch_micro.Infrastructure.Common;
using Infrastructure.Common.Logging;

namespace Infrastructure.Common.Repository;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context, ILogMessageManager<Role> logMessageManager) : base(context, logMessageManager)
    {

    }
}
