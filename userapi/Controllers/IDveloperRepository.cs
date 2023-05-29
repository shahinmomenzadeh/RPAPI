using Entity;
using userapi.Controllers;

namespace userapi;

public interface IDeveloperRepository : IGenericRepository<User>
{
    IEnumerable<User> GetPopularDevelopers(int count);
}