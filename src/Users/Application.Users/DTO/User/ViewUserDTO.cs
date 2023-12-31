﻿using Application.Common.DTO;
using Application.Users.DTO.Role;

namespace Application.Users.DTO.User;

public record ViewUserDTO : ResponseDTO
{
    public required string Name { get; set; }

    public required ViewRoleDTO Role { get; set; }
}
