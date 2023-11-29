using deathmatch_micro.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common;
public static class ConfigInfrastructureDependency
{
    public static IServiceCollection RegisterInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Data Source=applicationDb;Database=Deathmatch;Persist Security Info=True; User Id=sa; Password=RaynorRaiders44;TrustServerCertificate=True;MultipleActiveResultSets=true; Trusted_Connection=false;"));

        return services;
    }
}
