using Application.Common.Interface;
using Application.Users.DTO.User;

namespace Application.Users.Interfaces;

public interface IUserService : IService<ViewUserDTO, CreateUserDTO>
{
    public Task<ViewUserDTO> GetByNameAndPassword(string name, string password);
}
