using Application.Users.DTO.Role;
using Application.Users.DTO.User;
using Application.Users.Interfaces;
using AutoMapper;
using deathmatch_micro.Domain.Entities;
using deathmatch_micro.Domain.Interfaces;
using Infrastructure.Users.Services;
using Moq;

namespace UserUnitTests;
public class UserServiceUnitTest
{
    private readonly IMapper _mapper;
    public UserServiceUnitTest()
    {
        _mapper = MappingConfigForTests.CreateMapper();
    }

    [Fact]
    public async void UserService_Create_Success()
    {
        var createDTO = new CreateUserDTO() { Email = "totalit@gmail.com", Name = "totalit", Password = "123", RoleName = "User" };
        var expected = new ViewUserDTO() { Id = new Guid(), Name = createDTO.Name, Role = new ViewRoleDTO { Id = new Guid("13ad6213-7ed2-4fc0-9db6-900d462f2229"), Name = "User" } };

        var entity = _mapper.Map<User>(createDTO);

        var mockRoleRepository = new Mock<IRoleRepository>();
        mockRoleRepository.Setup(repository => repository.GetByName(It.IsAny<string>()).Result).Returns(new Role { Name = "User", Id = Guid.Parse("13ad6213-7ed2-4fc0-9db6-900d462f2229") });
        var mockUserRepository = new Mock<IUserRepository>();
        entity.Role.Id = Guid.Parse("13ad6213-7ed2-4fc0-9db6-900d462f2229");
        mockUserRepository.Setup(repository => repository.Create(It.Is<User>(User => User.Name == entity.Name)).Result).Returns(entity);


        IUserService service = new UserService(mockUserRepository.Object, mockRoleRepository.Object, _mapper);
        var actual = await service.Create(createDTO);
        Assert.Equal(expected, actual);
        mockRoleRepository.Verify(mock => mock.GetByName("User"));
    }

    [Fact]
    public void UserService_Create_FailedWhenRepositoryReturnsNull()
    {
        var createDTO = new CreateUserDTO() { Email = "totalit@gmail.com", Name = "totalit", Password = "123", RoleName = "User" };

        User entity = null;

        var mockRoleRepository = new Mock<IRoleRepository>();
        mockRoleRepository.Setup(repository => repository.Get(It.IsAny<Guid>()).Result).Returns(new Role { Name = "User", Id = Guid.Parse("13ad6213-7ed2-4fc0-9db6-900d462f2229") });
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(repository => repository.Create(_mapper.Map<User>(createDTO)).Result).Returns(entity);


        IUserService service = new UserService(mockUserRepository.Object, mockRoleRepository.Object, _mapper);
        Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(createDTO));
    }
}
