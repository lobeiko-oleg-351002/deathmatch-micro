using Application.Users.DTO.User;
using Application.Users.Interfaces;
using AutoMapper;
using deathmatch_micro.Domain.Entities;
using deathmatch_micro.Domain.Interfaces;
using Infrastructure.Common.Exceptions;
using Infrastructure.Common.Service;
using Infrastructure.Users.Exceptions;

namespace Infrastructure.Users.Services;

public class UserService : Service<User, ViewUserDTO, CreateUserDTO>, IUserService
{
    private readonly IRoleRepository _roleRepository;
    public UserService(IUserRepository UserRepository, IRoleRepository roleRepository, IMapper mapper)
        : base(UserRepository, mapper)
    {
        _roleRepository = roleRepository;
    }

    public async Task<ViewUserDTO> GetByNameAndPassword(string name, string password)
    {
        try
        {
            var entity = await ((IUserRepository)_repository).GetByNameAndPassword(name, password);
            return _mapper.Map<ViewUserDTO>(entity);
        }
        catch (ItemNotFoundException)
        {
            throw new UserNotFoundException();
        }
    }

    public override async Task<ViewUserDTO> Create(CreateUserDTO dto)
    {
        User entity = _mapper.Map<User>(dto);
        entity.Role = await _roleRepository.GetByName(dto.RoleName);
        var newUser = await _repository.Create(entity);
        return _mapper.Map<ViewUserDTO>(newUser);
    }

    public override async Task Update(CreateUserDTO entity)
    {
        await base.Update(entity);
    }
}
