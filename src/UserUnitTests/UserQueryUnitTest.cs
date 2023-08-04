using Application.Users.Interfaces;
using Application.Users.Queries;
using AutoMapper;
using deathmatch_micro.Application.Users.Queries;
using Moq;

namespace UserUnitTests;
public class UserQueryUnitTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserService> _mockUserService;
    private readonly Mock<IRoleService> _mockRoleService;
    public UserQueryUnitTest()
    {
        _mapper = MappingConfigForTests.CreateMapper();
        _mockUserService = new Mock<IUserService>();
        _mockRoleService = new Mock<IRoleService>();
    }

    [Fact]
    public void GetAllUsersQuery_Success()
    {
        var query = new GetAllUsersQuery();
        var handler = new GetAllUsersQueryHandler(_mockUserService.Object);

        var result = handler.Handle(query, new CancellationToken());

        Assert.NotNull(result);
        _mockUserService.Verify(mock => mock.GetAll());
    }

    [Fact]
    public void GetAllRolesQuery_Success()
    {
        var query = new GetAllRolesQuery();
        var handler = new GetAllRolesQueryHandler(_mockRoleService.Object);

        var result = handler.Handle(query, new CancellationToken());

        Assert.NotNull(result);
        _mockRoleService.Verify(mock => mock.GetAll());
    }
}
