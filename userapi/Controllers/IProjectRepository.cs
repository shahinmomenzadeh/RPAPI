using Entity;
using model.UserDto;
using userapi.Controllers;

namespace userapi;


public interface IProjectRepository : IGenericRepository<UserDto>
{
    List<User> GetPopularDevelopers(int count);
}