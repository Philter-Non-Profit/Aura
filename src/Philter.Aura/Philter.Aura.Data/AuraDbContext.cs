using Philter.Aura.Data.Models;

namespace Philter.Aura.Data;

[Coalesce]
public class AuraDbContext : DbContext
{
    public AuraDbContext()
    {
    }

    public AuraDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AuraUser> Users => Set<AuraUser>();

    public DbSet<House> Houses => Set<House>();

    public DbSet<Room> Rooms => Set<Room>();

    public DbSet<HouseManager> HouseManagers => Set<HouseManager>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AuraUser>()
            .Property(u => u.AuraUserId)
            .HasDefaultValueSql("newid()");

        // Remove cascading deletes.
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
    }
}