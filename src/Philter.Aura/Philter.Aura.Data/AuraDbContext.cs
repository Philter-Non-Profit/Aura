using Philter.Aura.Data.Models;

namespace Philter.Aura.Data;

[Coalesce]
public class AuraDbContext : DbContext
{
    public DbSet<AuraUser> Users => Set<AuraUser>();

    public DbSet<House> Houses => Set<House>();


    public AuraDbContext()
    {
    }

    public AuraDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AuraUser>()
            .HasMany(e => e.ManagedHouses)
            .WithMany(e => e.Managers)
            .UsingEntity(
                "HouseManagers",
                l => l.HasOne(typeof(House)).WithMany().HasForeignKey("HouseId").HasPrincipalKey(nameof(House.HouseId)),
                r => r.HasOne(typeof(AuraUser)).WithMany().HasForeignKey("ManagerId")
                    .HasPrincipalKey(nameof(AuraUser.AuraUserId)),
                j => j.HasKey("HouseId", "ManagerId"))
            .Property(u => u.AuraUserId)
            .HasDefaultValueSql("newid()");

        // Remove cascading deletes.
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
