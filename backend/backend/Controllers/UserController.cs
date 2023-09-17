using Microsoft.AspNetCore.Mvc;
using backend.Exceptions;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
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
    public async Task<IActionResult> GetUser(int id)
    {
        try
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }
        catch (UserNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
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