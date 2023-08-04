using deathmatch_micro.Domain.Entities;
using deathmatch_micro.Domain.Interfaces;
using Infrastructure.Common.Exceptions;
using Infrastructure.Common.Logging;
using Infrastructure.Common.Repository;
using Moq;

namespace UserUnitTests.RepositoryTest;
public class UserRepositoryUnitTest : IClassFixture<DatabaseFixture>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    public UserRepositoryUnitTest(DatabaseFixture databaseFixture)
    {
        var mockUserLogger= new Mock<ILogMessageManager<User>>();
        var mockRoleLogger = new Mock<ILogMessageManager<Role>>();
        _userRepository = new UserRepository(databaseFixture.DbContext, mockUserLogger.Object);
        _roleRepository = new RoleRepository(databaseFixture.DbContext, mockRoleLogger.Object);
    }

    [Fact]
    public async void UserRepository_Create_Success()
    {
        var expected = new User() { Id = new Guid(), Email = "test@gmail.com", Name = "testCreate", Password = "123", Role = _roleRepository.GetByName("User").Result };

        var actual = await _userRepository.Create(expected);

        Assert.Equal(expected, actual);
        Assert.False(actual.Id == Guid.Empty);
        await _userRepository.Delete(actual.Id);
    }

    [Fact]
    public void UserRepository_Create_FailedWithRoleNull()
    {
        var user = new User() { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = "123", Role = null };

        Assert.ThrowsAsync<DalCreateException>(() => _userRepository.Create(user));
    }

    [Fact]
    public async void UserRepository_GetByNameAndPassword_Success()
    {
        var source = new User() { Id = new Guid(), Email = "test@gmail.com", Name = "testName", Password = "passwordTest", Role = _roleRepository.GetByName("User").Result };

        var expected = await _userRepository.Create(source);
        var actual = await _userRepository.GetByNameAndPassword(source.Name, source.Password);

        Assert.Equal(expected, actual);

        await _userRepository.Delete(expected.Id);
    }

    [Fact]
    public async void UserRepository_GetByNameAndPassword_FailedOnWrongPassword()
    {
        var source = new User() { Id = new Guid(), Email = "test@gmail.com", Name = "testName", Password = "passwordTest", Role = _roleRepository.GetByName("User").Result };

        var actual = await _userRepository.Create(source);

        await Assert.ThrowsAsync<ItemNotFoundException>(async () => await _userRepository.GetByNameAndPassword(source.Name, "wrong password"));

        await _userRepository.Delete(actual.Id);
    }
}
