using deathmatch_micro.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace UserUnitTests.RepositoryTest;
public class DatabaseFixture : IDisposable
{
    public readonly ApplicationDbContext DbContext;
    public DatabaseFixture()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Deathmatch;Trusted_Connection=True;MultipleActiveResultSets=true");
        DbContext = new ApplicationDbContext(optionsBuilder.Options);
    }

    public void Dispose()
    {
        DbContext.Dispose();
    }
}
