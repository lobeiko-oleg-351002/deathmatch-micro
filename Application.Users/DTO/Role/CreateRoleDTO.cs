using Application.Common.DTO;

namespace Application.Users.DTO.Role;

public record CreateRoleDTO : CreateDTO
{
    public required string Name { get; set; }
}
