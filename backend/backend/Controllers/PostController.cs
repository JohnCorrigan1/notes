// using Microsoft.AspNetCore.Mvc;

// namespace backend.Controllers;
// [ApiController]
// [Route("api/[controller]")]
// public class postController : ControllerBase
// {

//     public List<Post> posts = new List<Post>();
//     public List<User> users = new List<User>();

//     public postController()
//     {
//         var OmegaChad = new User { username = "OmegaChad", id = 69 };
//         var AlphaVirgin = new User { username = "AlphaVirgin", id = 420 };
//         var BetaVirgin = new User { username = "BetaVirgin", id = 666 };


//         posts.Add(new Post { body = "post1", postedDate = DateTime.Now, likes = 0, author = OmegaChad, comments = new List<Comment>(), id = 1 });
//         posts.Add(new Post { body = "post2", postedDate = DateTime.Now, likes = 0, author = AlphaVirgin, comments = new List<Comment>(), id = 2 });
//         posts.Add(new Post { body = "post3", postedDate = DateTime.Now, likes = 0, author = BetaVirgin, comments = new List<Comment>(), id = 3 });

//     }

//     [HttpGet("getall", Name = "GetPosts")]
//     public IEnumerable<Post> GetPosts()
//     {
//         return posts;
//     }

//     [HttpGet("get/{id}", Name = "GetPost")]
//     public Post GetPost(int id)
//     {
//         return posts.Find(post => post.id == id);
//     }

//     [HttpPost("create", Name = "CreatePost")]
//     public Post CreatePost(Post post)
//     {
//         posts.Add(post);
//         return post;
//     }

//     [HttpPut("update/{id}", Name = "UpdatePost")]
//     public Post UpdatePost(int id, Post post)
//     {
//         var index = posts.FindIndex(post => post.id == id);
//         posts[index] = post;
//         return post;
//     }

//     [HttpDelete("delete/{id}", Name = "DeletePost")]
//     public void DeletePost(int id)
//     {
//         posts.RemoveAll(post => post.id == id);
//     }

//     [HttpGet("top3", Name = "GetTop5Posts")]
//     public IEnumerable<Post> GetTop5Posts()
//     {
//         return posts.OrderByDescending(post => post.likes).Take(3);
//     }

//     [HttpPost("like/{id}", Name = "LikePost")]
//     public Post LikePost(int id)
//     {
//         var post = posts.Find(post => post.id == id);
//         post.likes++;
//         return post;
//     }

//     [HttpPost("comment/{id}", Name = "CommentPost")]
//     public Post CommentPost(int id, Comment comment)
//     {
//         var post = posts.Find(post => post.id == id);
//         post.comments.Add(comment);
//         return post;
//     }
// }