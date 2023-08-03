using Application.Users.DTO.Role;
using Application.Users.DTO.User;
using AutoMapper;
using deathmatch_micro.Application.Users.Commands;
using deathmatch_micro.Domain.Entities;

namespace Infrastructure.Users.Mapping;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<User, ViewUserDTO>();
        CreateMap<CreateUserDTO, User>();
        CreateMap<CreateUserCommand, CreateUserDTO>();
        CreateMap<ViewRoleDTO, Role>().ReverseMap();
    }
}
