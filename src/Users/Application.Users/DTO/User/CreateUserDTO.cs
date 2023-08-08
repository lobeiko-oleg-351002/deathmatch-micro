using Application.Common.DTO;
using Application.Users.DTO.Role;

namespace Application.Users.DTO.User;

public record CreateUserDTO : CreateDTO
{
    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public required string RoleName { get; set; }
}
