using Entity;
using userapi.Controllers;

namespace userapi;


public interface IProjectRepository : IGenericRepository<User>
{
    List<User> GetPopularDevelopers(int count);
}