using Application.Common.DTO;

namespace Application.Common.Interface;

public interface IService<TEntity, UEntity>
    where TEntity : ViewDTO
    where UEntity : CreateDTO
{
    Task<TEntity> Create(UEntity entity);

    Task<List<TEntity>> GetAll();

    Task<TEntity> Get(string id);

    Task Delete(string id);

    Task Update(UEntity entity);

    public string GetKey(string id);
}
