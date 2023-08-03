using Application.Users.DTO.User;

namespace Application.Users.Interfaces;

public interface IUserValidationService
{
    void ValidateNewUser(CreateUserDTO user);

    void ValidateNameAndPassword(string name, string password);
}
