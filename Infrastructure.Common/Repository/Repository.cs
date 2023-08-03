using deathmatch_micro.Domain;
using deathmatch_micro.Domain.Interfaces;
using deathmatch_micro.Infrastructure.Common;
using Infrastructure.Common.Exceptions;
using Infrastructure.Common.Logging;

namespace Infrastructure.Common.Repository;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{ 
    protected readonly ApplicationDbContext _context;
    protected readonly ILogMessageManager<TEntity> _logMessageManager;

    public Repository(ApplicationDbContext context, ILogMessageManager<TEntity> logMessageManager)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logMessageManager = logMessageManager;
    }

    public virtual async Task Create(TEntity entity)
    {
        try
        {
            entity.Id = new Guid();
             _logMessageManager.LogEntityCreation(entity);
            var result = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            _logMessageManager.LogSuccess();
        }
        catch (Exception ex)
        {
            _logMessageManager.LogFailure(ex.Message);
            throw new DalCreateException(ex.Message);
        }
    }

    public async Task Delete(Guid id)
    {
        try
        {
            _logMessageManager.LogDelete(id);
            var entity = _context.Set<TEntity>().Single(e => e.Id == id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            _logMessageManager.LogSuccess();
        }
        catch (Exception ex)
        {
            _logMessageManager.LogFailure(ex.Message);
            throw new DalDeleteException(ex.Message);
        }
    }

    public virtual async Task<TEntity> Get(Guid id)
    {
        _logMessageManager.LogGet(id);
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity != null)
        {
            _logMessageManager.LogSuccess();
            return entity;
        }
        var ex = new ItemNotFoundException();
        _logMessageManager.LogFailure(ex.Message);
        throw ex;
    }

    public virtual IQueryable<TEntity> GetAll()
    {
        _logMessageManager.LogGetAll();
        var elements = _context.Set<TEntity>().AsQueryable();
        if (elements.Any())
        {
            _logMessageManager.LogSuccess();
            return elements;
        }
        var ex = new NoElementsException();
        _logMessageManager.LogFailure(ex.Message);
        throw ex;
    }

    public async Task Update(TEntity entity)
    {
        _logMessageManager.LogEntityUpdate(entity);
        var Entity = await _context.Set<TEntity>().FindAsync(entity.Id);
        if (Entity != null)
        {
            _context.Entry(Entity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            _logMessageManager.LogSuccess();
        }
        var ex = new ItemNotFoundException();
        _logMessageManager.LogFailure(ex.Message);
        throw ex;
    }
}
