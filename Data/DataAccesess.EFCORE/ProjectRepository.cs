using Entity;
using userapi;

namespace Data.DataAccess.EFCore;

public class ProjectRepository : GenericRepository<User>, IProjectRepository
{
    public ProjectRepository(AppDbContext context) : base(context)
    {
        
    }
    public List<User> GetPopularDevelopers(int count)
    {
        return _context.Users.OrderByDescending(d => d.Id).Take(count).ToList();
    }
   
    
}