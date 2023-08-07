using Application.Common.DTO;
using Application.Common.Interface;
using AutoMapper;
using deathmatch_micro.Domain;
using deathmatch_micro.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Service;

public class Service<TEntity, UEntity, YEntity> : IService<UEntity, YEntity>
     where TEntity : BaseEntity
     where UEntity : ViewDTO
     where YEntity : CreateDTO
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper _mapper;
    public Service(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<UEntity> Create(YEntity entity)
    {
        return _mapper.Map<UEntity>(await _repository.Create(_mapper.Map<TEntity>(entity)));
    }

    public virtual async Task Delete(string id)
    {
        await _repository.Delete(Guid.Parse(id));
    }

    public virtual async Task<List<UEntity>> GetAll()
    {
        var query = _repository.GetAll();
        var entities = await query.ToListAsync();
        return entities.Select(_mapper.Map<UEntity>).ToList();
    }

    public virtual async Task<UEntity> Get(string id)
    {
        var entity = await _repository.Get(Guid.Parse(id));
        return _mapper.Map<UEntity>(entity);
    }

    public virtual async Task Update(YEntity entity)
    {
        await _repository.Update(_mapper.Map<TEntity>(entity));
    }

    public string GetKey(string id)
    {
        return typeof(UEntity) + "_" + id;
    }
}
