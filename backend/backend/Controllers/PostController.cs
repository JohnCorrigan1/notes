using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{

    public List<Post> posts = new List<Post>();
    public List<User> users = new List<User>();

    public PostController()
    {
        var OmegaChad = new User { username = "OmegaChad", id = 69 };
        var AlphaVirgin = new User { username = "AlphaVirgin", id = 420 };
        var BetaVirgin = new User { username = "BetaVirgin", id = 666 };


        posts.Add(new Post { body = "post1", postedDate = DateTime.Now, likes = 0, author = OmegaChad, comments = new List<Comment>(), id = 1 });
        posts.Add(new Post { body = "post2", postedDate = DateTime.Now, likes = 0, author = AlphaVirgin, comments = new List<Comment>(), id = 2 });
        posts.Add(new Post { body = "post3", postedDate = DateTime.Now, likes = 0, author = BetaVirgin, comments = new List<Comment>(), id = 3 });

    }

    [HttpGet("getallposts", Name = "GetPosts")]
    public IEnumerable<Post> GetPosts()
    {
        return posts;
    }

    [HttpGet("{id}", Name = "GetPost")]
    public Post GetPost(int id)
    {
        return posts.Find(post => post.id == id);
    }

    [HttpPost("createPost", Name = "CreatePost")]
    public Post CreatePost(Post post)
    {
        posts.Add(post);
        return post;
    }

    [HttpPut("{id}", Name = "UpdatePost")]
    public Post UpdatePost(int id, Post post)
    {
        var index = posts.FindIndex(post => post.id == id);
        posts[index] = post;
        return post;
    }

    [HttpDelete("{id}", Name = "DeletePost")]
    public void DeletePost(int id)
    {
        posts.RemoveAll(post => post.id == id);
    }

    [HttpGet("top3", Name = "GetTop5Posts")]
    public IEnumerable<Post> GetTop5Posts()
    {
        return posts.OrderByDescending(post => post.likes).Take(3);
    }

    [HttpPost("{id}/like", Name = "LikePost")]
    public Post LikePost(int id)
    {
        var post = posts.Find(post => post.id == id);
        post.likes++;
        return post;
    }

    [HttpPost("{id}/comment", Name = "CommentPost")]
    public Post CommentPost(int id, Comment comment)
    {
        var post = posts.Find(post => post.id == id);
        post.comments.Add(comment);
        return post;
    }
}