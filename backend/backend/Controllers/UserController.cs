using Microsoft.AspNetCore.Mvc;
using backend.Exceptions;
namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userService.GetUsers();
    }

    [HttpGet("{id}", Name = "GetUser")]
    public async Task<User> GetUser(int id)
    {
        return await _userService.GetUser(id);
    }

    [HttpPost(Name = "CreateUser")]
    public async Task CreateUser(string username)
    {
        await _userService.CreateUser(username);
    }

    [HttpPut("update", Name = "UpdateUser")]
    public async Task<IActionResult> UpdateUser(User user)
    {
        try 
	    { 
            await _userService.UpdateUser(user);
            return Ok();
	    } 
	    catch (UserNotFoundException ex)
        {
            return NotFound(ex.Message);
	    }
    }
}