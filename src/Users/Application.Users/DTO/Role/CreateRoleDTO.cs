using Application.Common.DTO;

namespace Application.Users.DTO.Role;

public record CreateRoleDTO : RequestDTO
{
    public required string Name { get; set; }
}
