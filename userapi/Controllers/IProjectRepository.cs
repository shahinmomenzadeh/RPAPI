using Entity;
using userapi.Controllers;

namespace userapi;


public interface IProjectRepository : IGenericRepository<User>
{
    IEnumerable<User> GetPopularDevelopers(int count);
}