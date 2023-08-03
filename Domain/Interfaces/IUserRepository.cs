using deathmatch_micro.Domain.Entities;

namespace deathmatch_micro.Domain.Interfaces;
public interface IUserRepository : IRepository<User>
{
    public Task<User> GetByNameAndPassword(string name, string password);
}

