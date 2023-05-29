using Entity;

namespace Data.DataAccess.EFCore;

public class DeveloperRepository : GenericRepository<User>, IDeveloperRepository
{
    public DeveloperRepository(AppDbContext context) : base(context)
    {
    }
    public IEnumerable<User> GetPopularDevelopers(int count)
    {
        return _context.Users.OrderByDescending(d => d).Take(count).ToList();
    }
}