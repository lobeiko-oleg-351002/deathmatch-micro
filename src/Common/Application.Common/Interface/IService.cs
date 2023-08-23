using Application.Common.DTO;

namespace Application.Common.Interface;

public interface IService<TEntity, UEntity>
    where TEntity : ResponseDTO
    where UEntity : RequestDTO
{
    Task<TEntity> Create(UEntity entity);

    Task<List<TEntity>> GetAll();

    Task<TEntity> Get(Guid id);

    Task Delete(Guid id);

    Task Update(UEntity entity);

    public string GetKey(Guid id);
}
