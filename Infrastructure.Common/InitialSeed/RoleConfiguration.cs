using deathmatch_micro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Common.InitialSeed;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData
        (
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "User",
            }
        );
    }
}
