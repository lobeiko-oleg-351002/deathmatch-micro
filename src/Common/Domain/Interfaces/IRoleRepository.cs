using deathmatch_micro.Domain.Entities;

namespace deathmatch_micro.Domain.Interfaces;
public interface IRoleRepository : IRepository<Role>
{
    Task<Role> GetByName(string name);
}

