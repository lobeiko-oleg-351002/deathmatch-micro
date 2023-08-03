using Application.Common.DTO;

namespace Application.Users.DTO.Role;

public record ViewRoleDTO : ViewDTO
{
    public required string Name { get; set; }
}
