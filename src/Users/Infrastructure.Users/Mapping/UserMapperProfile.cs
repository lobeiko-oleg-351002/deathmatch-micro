﻿using Application.Users.DTO.Role;
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
        CreateMap<CreateUserDTO, User>()
            .ForMember(entity => entity.Id, dto => dto.MapFrom(x => Guid.Parse(x.Id)))
            .ForMember(entity => entity.Role, opt => opt.MapFrom(dto => new Role { Name = dto.RoleName }));
        CreateMap<CreateUserCommand, CreateUserDTO>().ForMember(x => x.Id, opt => opt.Ignore());
        //CreateMap<ViewRoleDTO, Role>().ForMember(entity => entity.Id, dto => dto.MapFrom(x => Guid.Parse(x.Id)));
        //CreateMap<Role, ViewRoleDTO>().ForMember(dto => dto.Id, entity => entity.MapFrom(x => x.Id.ToString()));
    }
}
