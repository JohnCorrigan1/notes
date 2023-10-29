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

    [HttpGet("{clerkId}", Name = "GetUser")]
    public async Task<IActionResult> GetUser(string clerkId)
    {
        try
        {
            var user = await _userService.GetUser(clerkId);
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

    public class NewUser
    {
        public string username { get; set; }
        public string clerkId { get; set; }
    } 
	

    [HttpPost(Name = "CreateUser")]
    public async Task CreateUser(NewUser user)
    {
        await _userService.CreateUser(user.username, user.clerkId);
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