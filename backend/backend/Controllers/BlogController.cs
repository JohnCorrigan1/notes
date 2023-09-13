using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    public List<User> users = new List<User>();
    public BlogController()
    {
        users.Add(new User { username = "user1" });
        users.Add(new User { username = "user2" });
        users.Add(new User { username = "user3" });
    }

    // [HttpGet(Name = "GetUsers")]
    [HttpGet("users", Name = "GetUsersBlog")]
    public IEnumerable<User> GetUsers()
    {
        return users;
    }


}

