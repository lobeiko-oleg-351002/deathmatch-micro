using Application.Users.Interfaces;
using deathmatch_micro.Domain.Entities;
using deathmatch_micro.Domain.Interfaces;
using Infrastructure.Common.Logging;
using Infrastructure.Common.Repository;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Users.Services;

namespace Infrastructure.Users;

public static class ConfigUserDependency
{
    public static IServiceCollection RegisterUserDependencies(
    this IServiceCollection services)
    {
        services.AddScoped<ILogMessageManager<User>, LogMessageManager<User>>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserValidationService, UserValidationService>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<ILogMessageManager<Role>, LogMessageManager<Role>>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoleService, RoleService>();

        return services;
    }
}
