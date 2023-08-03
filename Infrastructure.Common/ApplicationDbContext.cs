using deathmatch_micro.Domain.Entities;
using Infrastructure.Common.InitialSeed;
using Microsoft.EntityFrameworkCore;

namespace deathmatch_micro.Infrastructure.Common;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}
