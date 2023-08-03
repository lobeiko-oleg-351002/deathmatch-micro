using Application.Users.DTO.Role;
using AutoMapper;
using deathmatch_micro.Domain.Entities;

namespace Infrastructure.Users.Mapping;

public class RoleMapperProfile : Profile
{
    public RoleMapperProfile()
    {
        CreateMap<Role, ViewRoleDTO>();
    }
}
