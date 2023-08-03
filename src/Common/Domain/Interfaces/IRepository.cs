namespace deathmatch_micro.Domain.Interfaces;

public interface IRepository<TEntity>
    where TEntity : BaseEntity

{
    Task<TEntity> Create(TEntity entity);

    IQueryable<TEntity> GetAll();

    Task<TEntity> Get(Guid id);

    Task Delete(Guid id);

    Task Update(TEntity entity);
}
