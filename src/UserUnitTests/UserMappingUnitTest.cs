using Application.Users.DTO.Role;
using Application.Users.DTO.User;
using AutoMapper;
using deathmatch_micro.Domain.Entities;

namespace UserUnitTests;

public class UserMappingUnitTest
{
    private readonly IMapper _mapper;

    public UserMappingUnitTest()
    {
        _mapper = MappingConfigForTests.CreateMapper();
    }
    public static IEnumerable<object[]> UserEntitiesComplete
    {
        get
        {
            return new[]
            {
                new object[] { new User { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = "123", Role = new Role() { Name = "User" } } },
                new object[] { new User { Id = new Guid(), Email = string.Empty, Name = "totalit", Password = "123", Role = new Role() { Name = "User" } } }
            };
        }
    }

    public static IEnumerable<object[]> UserCreateDTOsComplete
    {
        get
        {
            return new[]
            {
                new object[] { new CreateUserDTO { Id = "65fd2816-d5ed-467b-d4b1-08db97217cbd", Email = "totalit@gmail.com", Name = "totalit", Password = "123", Role = new ViewRoleDTO() { Id = "65fd2816-d5ed-467b-d4b1-08db97217cbd", Name = "User" } } },
                new object[] { new CreateUserDTO { Id = "65fd2816-d5ed-467b-d4b1-08db97217cbd", Email = string.Empty, Name = "totalit", Password = "123", Role = new ViewRoleDTO() { Id = "65fd2816-d5ed-467b-d4b1-08db97217cbd", Name = "User" } } }
                };
        }
    }

    [Fact]
    public void Automapper_Configuration_SuccessInit()
    {
        var config = MappingConfigForTests.CreateMapperConfig();
        config.AssertConfigurationIsValid();
    }

    [Theory, MemberData(nameof(UserEntitiesComplete))]
    public void UserMapper_ConvertToViewDTO_SuccessFieldConverting(User entity)
    {
        var expected = new ViewUserDTO { Id = entity.Id.ToString(), Name = entity.Name, Role = _mapper.Map <ViewRoleDTO>(entity.Role) };
        var actual = _mapper.Map<ViewUserDTO>(entity);

        Assert.Equal(expected.Role.Name, actual.Role.Name);
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.Name, actual.Name);
    }

    [Theory, MemberData(nameof(UserCreateDTOsComplete))]
    public void UserMapper_ConvertToEntity_SuccessFieldConverting(CreateUserDTO createDTO)
    {
        var expected = new User { Id = Guid.Parse(createDTO.Id), Name = createDTO.Name, Role = _mapper.Map<Role>(createDTO.Role), Email = createDTO.Email, Password = createDTO.Password };
        var actual = _mapper.Map<User>(createDTO);

        Assert.Equal(expected.Role.Name, actual.Role.Name);
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Password, actual.Password);
        Assert.Equal(expected.Email, actual.Email);
    }
}