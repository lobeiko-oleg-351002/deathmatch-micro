using Application.Users.DTO.Role;
using Application.Users.DTO.User;
using Application.Users.Interfaces;
using Infrastructure.Users.Exceptions;
using Infrastructure.Users.Services;

namespace UserUnitTests;
public class UserValidationServiceUnitTest
{
    private readonly IUserValidationService _userValidationService = new UserValidationService();

    public static IEnumerable<object[]> UserEntitiesEmptyOrIncorrectEmail
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserDTO { Id = "", Email = "a", Name = "totalit", Password = "123", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                    new object[] { new CreateUserDTO { Id = "", Email = string.Empty, Name = "totalit", Password = "123", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                    new object[] { new CreateUserDTO { Id = "", Email = "123", Name = "totalit", Password = "123", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                 };
        }
    }

    public static IEnumerable<object[]> UserEntitiesRoleIsNull
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserDTO { Id = "", Email = "totalit@gmail.com", Name = "totalit", Password = "123", Role = null } },
                };
        }
    }

    public static IEnumerable<object[]> UserEntitiesNameIsEmptyOrIncorrect
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserDTO { Id = "", Email = "totalit@gmail.com", Name = string.Empty, Password = "123", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                    new object[] { new CreateUserDTO { Id = "", Email = "totalit@gmail.com", Name = "a", Password = "123", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                };
        }
    }

    public static IEnumerable<object[]> UserEntitiesPasswordIsEmptyOrIncorrect
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserDTO { Id = "", Email = "totalit@gmail.com", Name = "totalit", Password = string.Empty, Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                    new object[] { new CreateUserDTO { Id = "", Email = "totalit@gmail.com", Name = "totalit", Password = "12", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                };
        }
    }

    public static IEnumerable<object[]> UserEntitiesValid
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserDTO { Id = "", Email = "totalit@gmail.com", Name = "tot", Password = "123", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                    new object[] { new CreateUserDTO { Id = "", Email = "totalit@gmail.com", Name = "totalit", Password = "asdfasdf", Role = new ViewRoleDTO() {Id = "", Name = "User" } } },
                 };
        }
    }

    [Fact]
    public void UserValidationService_ValidateNewUser_UserIsNullException()
    {
        Assert.Throws<UserValidationExceptionUserIsNull>(() => _userValidationService.ValidateNewUser(null));
    }

    [Theory, MemberData(nameof(UserEntitiesEmptyOrIncorrectEmail))]
    public void UserValidationService_ValidateNewUser_IncorrectEmailException(CreateUserDTO entity)
    {
        Assert.Throws<UserValidationExceptionInvalidEmail>(() => _userValidationService.ValidateNewUser(entity));
    }

    [Theory, MemberData(nameof(UserEntitiesNameIsEmptyOrIncorrect))]
    public void UserValidationService_ValidateNewUser_InvalidNameException(CreateUserDTO entity)
    {
        Assert.Throws<UserValidationExceptionInvalidName>(() => _userValidationService.ValidateNewUser(entity));
    }

    [Theory, MemberData(nameof(UserEntitiesPasswordIsEmptyOrIncorrect))]
    public void UserValidationService_ValidateNewUser_InvalidPasswordException(CreateUserDTO entity)
    {
        Assert.Throws<UserValidationExceptionInvalidPassword>(() => _userValidationService.ValidateNewUser(entity));
    }

    [Theory, MemberData(nameof(UserEntitiesRoleIsNull))]
    public void UserValidationService_ValidateNewUser_RoleIsNullException(CreateUserDTO entity)
    {
        Assert.Throws<UserValidationExceptionRoleIsNull>(() => _userValidationService.ValidateNewUser(entity));
    }

    [Theory]
    [InlineData("", "1234")]
    [InlineData("12", "1234")]
    public void UserValidationService_ValidateNameAndPassword_FailedOnInvalidName(string name, string password)
    {
        Assert.Throws<UserValidationExceptionInvalidName>(() => _userValidationService.ValidateNameAndPassword(name, password));
    }

    [Theory]
    [InlineData("123", "12")]
    [InlineData("1234", "")]
    public void UserValidationService_ValidateNameAndPassword_FailedOnInvalidPassword(string name, string password)
    {
        Assert.Throws<UserValidationExceptionInvalidPassword>(() => _userValidationService.ValidateNameAndPassword(name, password));
    }

    [Theory, MemberData(nameof(UserEntitiesValid))]
    public void UserValidationService_ValidateNewUser_Success(CreateUserDTO entity)
    {
        var exception = Record.Exception(() => _userValidationService.ValidateNewUser(entity));
        Assert.Null(exception);
    }


}
