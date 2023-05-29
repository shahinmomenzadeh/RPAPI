using Entity;
using model.UserDto;
using userapi;

namespace Data.DataAccess.EFCore;

public class ProjectRepository : GenericRepository<UserDto>, IProjectRepository
{
    public ProjectRepository(AppDbContext context) : base(context)
    {
        
    }
    public List<User> GetPopularDevelopers(int count)
    {
        return _context.Users.OrderByDescending(d => d).Take(count).ToList();
    }
   
}