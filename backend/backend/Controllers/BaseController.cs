// using Microsoft.AspNetCore.Mvc;
// using backend.Models;

// namespace backend.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class baseController : ControllerBase
// {
//     public static List<User> users = new List<User>();
//     // public List<User> users = new List<User>();
//     public baseController()
//     {
//         users.Add(new User { Username = "user1", Id = 1 });
//         users.Add(new User { Username = "user2", Id = 2 });
//         users.Add(new User { Username = "user3", Id = 3 });
//         User epicUser = new User("epicUser", 3);
//     }

//     [HttpGet(Name = "GetUsers")]
//     public IEnumerable<User> GetUsers()
//     {
//         return users;
//     }


// }

