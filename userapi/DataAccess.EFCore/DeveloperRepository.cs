using Entity;
using model.UserDto;
using userapi;

namespace Data.DataAccess.EFCore;

public class DeveloperRepository : GenericRepository<UserDto>, IProjectRepository
{ 
    public DeveloperRepository(AppDbContext context) : base(context)
    {
    }
    public List<User> GetPopularDevelopers(int count)
    {
        return _context.Users.OrderByDescending(d => d).Take(count).ToList();
    }
}