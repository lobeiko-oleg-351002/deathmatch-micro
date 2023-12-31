﻿using Application.Users.Validation;
using deathmatch_micro.Application.Users.Commands;
using FluentValidation.TestHelper;

namespace UserUnitTests;
public class UserFluentValidationUnitTest
{
    private readonly CreateUserCommandValidator _createUserCommandValidator;

    public UserFluentValidationUnitTest()
    {
        _createUserCommandValidator = new CreateUserCommandValidator();
    }

    public static IEnumerable<object[]> UserEntitiesEmptyOrIncorrectEmail
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserCommand { Email = "a", Name = "totalit", Password = "123", RoleName = "User" } },
                    new object[] { new CreateUserCommand { Email = string.Empty, Name = "totalit", Password = "123", RoleName = "User" } },
                    new object[] { new CreateUserCommand { Email = "123", Name = "totalit", Password = "123", RoleName = "User" } },
                 };
        }
    }

    public static IEnumerable<object[]> UserEntitiesRoleIsNull
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = "totalit", Password = "123", RoleName = String.Empty } },
                };
        }
    }

    public static IEnumerable<object[]> UserEntitiesNameIsEmptyOrIncorrect
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = string.Empty, Password = "123", RoleName = "User" } },
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = "a", Password = "123", RoleName = "User" } },
                };
        }
    }

    public static IEnumerable<object[]> UserEntitiesPasswordIsEmptyOrIncorrect
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = "totalit", Password = string.Empty, RoleName = "User" } },
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = "totalit", Password = "12", RoleName = "User" } },
                };
        }
    }

    public static IEnumerable<object[]> UserEntitiesValid
    {
        get
        {
            return new[]
            {
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = "tot", Password = "123", RoleName = "User" } },
                    new object[] { new CreateUserCommand { Email = "totalit@gmail.com", Name = "totalit", Password = "asdfasdf", RoleName = "User" } },
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
        response.ShouldHaveValidationErrorFor(x => x.RoleName);
    }

    [Theory, MemberData(nameof(UserEntitiesValid))]
    public void CreateUserCommand_ValidateNewUser_Success(CreateUserCommand entity)
    {
        var response = _createUserCommandValidator.TestValidate(entity);
        response.ShouldNotHaveAnyValidationErrors();
    }
}
