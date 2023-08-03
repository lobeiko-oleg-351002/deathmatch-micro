using deathmatch_micro.Domain.Entities;
using deathmatch_micro.Domain.Interfaces;
using deathmatch_micro.Infrastructure.Common;
using Infrastructure.Common.Exceptions;
using Infrastructure.Common.Logging;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context, ILogMessageManager<User> logMessageManager) : base(context, logMessageManager)
    {

    }

    public async Task<User> GetByNameAndPassword(string name, string password)
    {
        _logMessageManager.LogCustomMessage("GetByNameAndPassword. Name: " + name + " Password: " + password);
        var entity = await _context.Users.Include(role => role.Role).FirstOrDefaultAsync(e => e.Name == name && e.Password == password);
        if (entity == null)
        {
            var ex = new ItemNotFoundException();
            _logMessageManager.LogFailure(ex.Message);
            throw ex;
        }
        _logMessageManager.LogSuccess();
        return entity;
    }

    public override async Task<User> Get(Guid id)
    {
        _logMessageManager.LogGet(id);
        User User = await _context.Users.Include(role => role.Role).FirstOrDefaultAsync(user => user.Id == id);
        if (User == null)
        {
            var ex = new ItemNotFoundException();
            _logMessageManager.LogFailure(ex.Message);
            throw ex;
        }
        _logMessageManager.LogSuccess();
        return User;
    }

    public override IQueryable<User> GetAll()
    {
        _logMessageManager.LogGetAll();
        var elements = _context.Users.Include(role => role.Role).AsQueryable();
        if (elements.Any())
        {
            _logMessageManager.LogSuccess();
            return elements;
        }
        var ex = new NoElementsException();
        _logMessageManager.LogFailure(ex.Message);
        throw ex;
    }

    public override async Task<User> Create(User entity)
    {
        try
        {
            entity.Id = new Guid();
            _logMessageManager.LogEntityCreation(entity);
            entity.Role = await _context.Roles.FirstOrDefaultAsync(role => role.Id == entity.Role.Id);
            var result = await _context.Set<User>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        catch (Exception ex)
        {
            _logMessageManager.LogFailure(ex.Message);
            throw new DalCreateException(ex.Message);
        }
    }
}
