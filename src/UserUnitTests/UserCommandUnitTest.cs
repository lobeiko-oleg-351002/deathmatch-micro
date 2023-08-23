using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Users.DTO.Role;
using Application.Users.DTO.User;
using Application.Users.Interfaces;
using AutoMapper;
using deathmatch_micro.Application.Users.Commands;
using Moq;

namespace UserUnitTests;
public class UserCommandUnitTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserService> _mockUserService;
    public UserCommandUnitTest()
    {
        _mapper = MappingConfigForTests.CreateMapper();
        _mockUserService = new Mock<IUserService>();
    }

    [Fact]
    public void CreateUserCommand_Success()
    {
        var cmd = new CreateUserCommand { Name = "commandUser", Password = "1234", Email = "test@test.com", RoleName = "User" };
        var handler = new CreateUserCommandHandler(_mockUserService.Object, _mapper);

        var result = handler.Handle(cmd, new CancellationToken());

        Assert.NotNull(result);
        _mockUserService.Verify(mock => mock.Create(_mapper.Map<CreateUserDTO>(cmd)));
    }

    [Fact]
    public void RemoveUserCommand_Success()
    {
        var cmd = new RemoveUserByIdCommand { Id = new Guid() };
        var handler = new RemoveUserCommandHandler(_mockUserService.Object);

        var result = handler.Handle(cmd, new CancellationToken());

        Assert.NotNull(result);
        _mockUserService.Verify(mock => mock.Delete(cmd.Id));
    }
}
