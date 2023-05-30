using Entity;
using Microsoft.AspNetCore.Mvc;
using userapi;

namespace NEWAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class api_rp_Controller : ControllerBase
{
    private IProjectRepository _repository;

    public api_rp_Controller(IProjectRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet("api/users")]
    public IActionResult GetAllUsers()
    {
        var users = _repository.GetAll();
        return Ok(users);
    }
    [HttpPost("api/users")]
    public ActionResult AddUser([FromBody] User userDto)
    {
        if (userDto == null)
        {
            return BadRequest();
        }
        var model = new User()
        {
            cardid = userDto.cardid,
            lastname = userDto.lastname,
            Name = userDto.Name,
            ImageUrl = userDto.ImageUrl,
           
        };
        _repository.Add(model);
        return CreatedAtAction(nameof(AddUser),new { id = userDto.Id }, userDto);
    }
    }
