using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Philter.Aura.Data;

public class DevelopmentAppDbContextFactory : IDesignTimeDbContextFactory<AuraDbContext>
{
    public AuraDbContext CreateDbContext(string[] args)
    {
        // This is only used when adding migrations and updating the database from the cmd line.
        // It shouldn't ever be used in code where it might end up running in production.
        var builder = new DbContextOptionsBuilder<AuraDbContext>();
        builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Philter-Aura;Trusted_Connection=True;MultipleActiveResultSets=True;");
        return new AuraDbContext(builder.Options);
    }
}
