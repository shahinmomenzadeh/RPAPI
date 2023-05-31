using Entity;
using Microsoft.AspNetCore.Mvc;
using userapi;
using userapi.Controllers;

namespace NEWAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserApicontroller : ControllerBase
{
    private IGenericRepository<User> _repository;

    public UserApicontroller(IGenericRepository<User> repository)
    {
        _repository = repository;
    }
    
    [HttpGet("[action]/{id:int}")]
    public ActionResult GetUser(int id)
    {
        if (id == 0)
        {
            return Ok(BadRequest());
        }
        var user = _repository.GetById(id);

        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpGet("api/users")]
    public IActionResult GetAllUsers()
    {
        var users = _repository.GetAll();
        return Ok(users);
    }
    [HttpPost]
    public ActionResult AddUser([FromBody] User userDto)
    {
        if (userDto == null)
        {
            return BadRequest();
        }

        var model = new User
        {
            cardid = userDto.cardid,
            lastname = userDto.lastname,
            Name = userDto.Name,
            ImageUrl = userDto.ImageUrl,
        };

        try
        {
            _repository.Add(model);
        }
        catch (Exception ex)
        {
          
            return StatusCode(500, ex.Message);
        }
        
        return CreatedAtAction(nameof(AddUser), new { id = model.Id }, model);
    }
    [HttpDelete("[action]/{id:int}")]
    public ActionResult DeleteUser(int id)
    { 
        var user = _repository.GetById(id);
        if (user == null)
        {
            return NotFound();
        }
        _repository.Delete(id);
        
        return NoContent();
    }
    [HttpPut("[action]/{id:int}")]
    public ActionResult UpdateUser(int id, [FromBody] User userDto)
    {
        if (userDto == null || userDto.Id != id)
        {
            return BadRequest();
        }
        var todo = _repository.GetById(id);
        if (todo == null)
        {
            return NotFound();
        }
        todo.Name = userDto.Name;
        todo.lastname = userDto.lastname;
        todo.cardid = userDto.cardid;
        todo.ImageUrl = userDto.ImageUrl;
        _repository.Update(todo);
        
        return NoContent();
    }

    }
