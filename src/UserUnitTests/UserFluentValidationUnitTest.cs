using Application.Users.DTO.Role;
using Application.Users.DTO.User;
using Application.Users.Interfaces;
using Application.Users.Validation;
using deathmatch_micro.Application.Users.Commands;
using FluentValidation.TestHelper;
using Infrastructure.Users.Exceptions;
using Infrastructure.Users.Services;

namespace UserUnitTests;
public class UserFluentValidationUnitTest
{
    private readonly CreateUserCommandValidator _createUserCommandValidator;
    private readonly RemoveUserByIdCommandValidator _removeUserByIdCommandValidator;

    public UserFluentValidationUnitTest()
    {
        _createUserCommandValidator = new CreateUserCommandValidator();
        _removeUserByIdCommandValidator = new RemoveUserByIdCommandValidator();
    }

    public static IEnumerable<object[]> UserEntitiesEmptyOrIncorrectEmail
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserCommand { Email = "a", Name = "totalit", Password = "123", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                    new object[] { new CreateUserCommand { Email = string.Empty, Name = "totalit", Password = "123", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                    new object[] { new CreateUserCommand { Email = "123", Name = "totalit", Password = "123", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                 };
        }
    }

    public static IEnumerable<object[]> UserEntitiesRoleIsNull
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = "totalit", Password = "123", Role = null } },
                };
        }
    }

    public static IEnumerable<object[]> UserEntitiesNameIsEmptyOrIncorrect
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = string.Empty, Password = "123", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = "a", Password = "123", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                };
        }
    }

    public static IEnumerable<object[]> UserEntitiesPasswordIsEmptyOrIncorrect
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = "totalit", Password = string.Empty, Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = "totalit", Password = "12", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                };
        }
    }

    public static IEnumerable<object[]> UserEntitiesValid
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = "tot", Password = "123", Role = new ViewRoleDTO() { Id = "", Name = "User" } } },
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = "totalit", Password = "asdfasdf", Role = new ViewRoleDTO() {Id = "", Name = "User" } } },
                 };
        }
    }


    [Theory, MemberData(nameof(UserEntitiesEmptyOrIncorrectEmail))]
    public void CreateUserCommand_ValidateNewUser_IncorrectEmailException(CreateUserCommand entity)
    {
        var response = _createUserCommandValidator.TestValidate(entity);
        response.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Theory, MemberData(nameof(UserEntitiesNameIsEmptyOrIncorrect))]
    public void CreateUserCommand_ValidateNewUser_InvalidNameException(CreateUserCommand entity)
    {
        var response = _createUserCommandValidator.TestValidate(entity);
        response.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Theory, MemberData(nameof(UserEntitiesPasswordIsEmptyOrIncorrect))]
    public void CreateUserCommand_ValidateNewUser_InvalidPasswordException(CreateUserCommand entity)
    {
        var response = _createUserCommandValidator.TestValidate(entity);
        response.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Theory, MemberData(nameof(UserEntitiesRoleIsNull))]
    public void CreateUserCommand_ValidateNewUser_RoleIsNullException(CreateUserCommand entity)
    {
        var response = _createUserCommandValidator.TestValidate(entity);
        response.ShouldHaveValidationErrorFor(x => x.Role);
    }

    [Theory, MemberData(nameof(UserEntitiesValid))]
    public void CreateUserCommand_ValidateNewUser_Success(CreateUserCommand entity)
    {
        var response = _createUserCommandValidator.TestValidate(entity);
        response.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void RemoveUserCommand_ValidateNewUser_IdIsNullException()
    {
        var response = _removeUserByIdCommandValidator.TestValidate(new RemoveUserByIdCommand { Id = null });
        response.ShouldHaveValidationErrorFor(x => x.Id);
    }

    [Fact]
    public void RemoveUserCommand_ValidateNewUser_Success()
    {
        var response = _removeUserByIdCommandValidator.TestValidate(new RemoveUserByIdCommand { Id = "13d54b8e-2c1f-4e35-49fb-08db94cbee6d" });
        response.ShouldNotHaveValidationErrorFor(x => x.Id);
    }


}
