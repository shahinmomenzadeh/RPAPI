using Data.DataAccess.EFCore;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        var repository = new GenericRepository<User>(dbContext);
    }

    public AppDbContext dbContext { get; set; }

    public DbSet<User> Users { get; set; }
}