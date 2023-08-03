using Application.Users.DTO.Role;
using Application.Users.Interfaces;
using AutoMapper;
using deathmatch_micro.Domain.Entities;
using deathmatch_micro.Domain.Interfaces;
using Infrastructure.Common.Service;

namespace Infrastructure.Users.Services;

public class RoleService : Service<Role, ViewRoleDTO, CreateRoleDTO>, IRoleService
{
    public RoleService(IRoleRepository RoleRepository, IMapper mapper)
        : base(RoleRepository, mapper)
    {

    }

}
