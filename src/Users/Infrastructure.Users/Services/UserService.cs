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
    private readonly IUserValidationService _userValidationService;
    public UserService(IUserRepository UserRepository, IUserValidationService userValidationService, IMapper mapper)
        : base(UserRepository, mapper)
    {
        _userValidationService = userValidationService;
    }

    public async Task<ViewUserDTO> GetByNameAndPassword(string name, string password)
    {
        _userValidationService.ValidateNameAndPassword(name, password);
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

    public override async Task Create(CreateUserDTO entity)
    {
        _userValidationService.ValidateNewUser(_mapper.Map<CreateUserDTO>(entity));
        await base.Create(entity);
    }

    public override async Task Update(CreateUserDTO entity)
    {
        _userValidationService.ValidateNewUser(_mapper.Map<CreateUserDTO>(entity));
        await base.Update(entity);
    }
}
