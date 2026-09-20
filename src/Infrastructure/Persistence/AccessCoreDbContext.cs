using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccessCore.Infrastructure.Persistence;

public class AccessCoreDbContext : DbContext
{
    public DbSet<PersonalAccount> personalAccounts { get; set; }
    public AccessCoreDbContext(
        DbContextOptions<AccessCoreDbContext> options
    ) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AccessCoreDbContext).Assembly
        );

        base.OnModelCreating(modelBuilder);
    }
}