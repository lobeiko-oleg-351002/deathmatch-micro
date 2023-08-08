using Application.Users.DTO.Role;
using AutoMapper;
using deathmatch_micro.Domain.Entities;

namespace Infrastructure.Users.Mapping;

public class RoleMapperProfile : Profile
{
    public RoleMapperProfile()
    {
        CreateMap<Role, ViewRoleDTO>()
            .ForMember(dto => dto.Id, entity => entity.MapFrom(x => x.Id.ToString()))
            .ForMember(dto => dto.Name, entity => entity.MapFrom(x => x.Name));
    }
}
