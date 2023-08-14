using deathmatch_micro.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common;
public static class ConfigInfrastructureDependency
{
    public static IServiceCollection RegisterInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Deathmatch;Trusted_Connection=True;MultipleActiveResultSets=true"));

        return services;
    }
}
