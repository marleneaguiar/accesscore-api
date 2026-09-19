using Microsoft.EntityFrameworkCore;

namespace AccessCore.Infrastructure.Persistence;

public class AccessCoreDbContext : DbContext
{
    public AccessCoreDbContext(
        DbContextOptions<AccessCoreDbContext> options
    ) : base(options)
    {
    }
}