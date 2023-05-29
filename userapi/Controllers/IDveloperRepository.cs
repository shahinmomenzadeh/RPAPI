using Entity;
using model.UserDto;
using userapi.Controllers;

namespace userapi;

public interface IDeveloperRepository : IGenericRepository<UserDto>
{
    IEnumerable<UserDto> GetPopularDevelopers(int count);
}