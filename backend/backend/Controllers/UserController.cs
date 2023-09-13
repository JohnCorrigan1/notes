using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    public List<User> users = new List<User>();
    public UserController()
    {
        users.Add(new User { username = "user1", id = 1 });
        users.Add(new User { username = "user2", id = 2 });
        users.Add(new User { username = "user3", id = 3 });
    }

    [HttpGet("users", Name = "GetUsers")]
    public IEnumerable<User> GetUsers()
    {
        return users;
    }

    [HttpGet("users/{id}", Name = "GetUser")]
    public User GetUser(int id)
    {
        return users.Find(user => user.id == id);
    }

    [HttpPost("users", Name = "CreateUser")]
    public User CreateUser(User user)
    {
        users.Add(user);
        return user;
    }

    [HttpPut("users/{id}", Name = "UpdateUser")]
    public User UpdateUser(int id, User user)
    {
        var index = users.FindIndex(user => user.id == id);
        users[index] = user;
        return user;
    }
}
