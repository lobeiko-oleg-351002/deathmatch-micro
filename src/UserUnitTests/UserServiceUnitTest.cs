﻿using Application.Users.DTO.Role;
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
        var createDTO = new CreateUserDTO() { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = "123", Role = new ViewRoleDTO { Name = "User" } };
        var expected = new ViewUserDTO() { Id = createDTO.Id, Name = createDTO.Name, Role = createDTO.Role };

        var entity = _mapper.Map<User>(createDTO);

        var mockRepository = new Mock<IUserRepository>();
        mockRepository.Setup(repository => repository.Create(It.Is<User>(User => User.Name == entity.Name)).Result).Returns(entity);


        IUserValidationService userValidationService = new UserValidationService();

        IUserService service = new UserService(mockRepository.Object, userValidationService, _mapper);
        var actual = await service.Create(createDTO);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void UserService_Create_FailedWhenRepositoryReturnsNull()
    {
        var createDTO = new CreateUserDTO() { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = "123", Role = new ViewRoleDTO { Name = "User" } };

        User entity = null;

        var mockRepository = new Mock<IUserRepository>();
        mockRepository.Setup(repository => repository.Create(_mapper.Map<User>(createDTO)).Result).Returns(entity);


        IUserValidationService userValidationService = new UserValidationService();

        IUserService service = new UserService(mockRepository.Object, userValidationService, _mapper);
        Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(createDTO));
    }
}