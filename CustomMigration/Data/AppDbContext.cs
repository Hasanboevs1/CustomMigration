using Microsoft.EntityFrameworkCore;

namespace CustomMigration.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
        
    }
}
