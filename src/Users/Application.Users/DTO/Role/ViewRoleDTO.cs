using Application.Common.DTO;

namespace Application.Users.DTO.Role;

public record ViewRoleDTO : ResponseDTO
{
    public required string Name { get; set; }
}
