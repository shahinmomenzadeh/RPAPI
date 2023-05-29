using Entity;

namespace Data.DataAccess.EFCore;

public class ProjectRepository : GenericRepository<User>, IProjectRepository
{
    public ProjectRepository(AppDbContext context) : base(context)
    {
        
    }
}