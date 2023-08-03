using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deathmatch_micro.Domain.Entities;
using deathmatch_micro.Domain.Interfaces;
using deathmatch_micro.Infrastructure.Common;
using Infrastructure.Common.Logging;
using Infrastructure.Common.Repository;
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
