using Microsoft.AspNetCore.Mvc;
using backend.Exceptions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : Controller
{
    private readonly IPostService _postService;
    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet(Name = "GetPosts")]
    public async Task<IEnumerable<PostMetaData>> GetPosts()
    {
        return await _postService.GetPosts();
    }

    [HttpGet("{slug}", Name = "GetPost")]
    public async Task<IActionResult> GetPost(string slug)
    {
        return await _postService.GetPost(slug) switch
        {
            PostQueryResult post => Ok(post),
            _ => NotFound()
        };
    }

    [HttpGet("{clerk_id}", Name = "GetUserPosts")]
    public async Task<IEnumerable<PostMetaData>> GetUserPosts(string clerk_id) 
    {
        return await _postService.GetUserPosts(clerk_id); 
    }

    [HttpPost(Name = "CreatePost")]
    public async Task<IActionResult> CreatePost()
    {
        try
        {
            using (StreamReader reader = new StreamReader(HttpContext.Request.Body))
            {
                string requestBody = await reader.ReadToEndAsync();
                var json = JsonConvert.DeserializeObject<PostBody>(requestBody);
                await _postService.CreatePost(json);
            }
            return Ok();
        }
        catch (Exception e)
        {
            //return NotFound(ex.Message);
            return NotFound(e.Message);
        }

    }

    // [HttpGet("users/{userId}", Name = "GetPostsByUserId")]
    // public async Task<IEnumerable<Post>> GetPostsByUserId(int userId)
    // {
    //     return await _postService.GetPostsByUserId(userId);
    // }

    // [HttpGet("bydate", Name = "GetPostsByDate")]
    // public async Task<IEnumerable<Post>> GetPostsByDate()
    // {
    //     return await _postService.GetPostsByDate();
    // }

    // [HttpGet("bylikes", Name = "GetPostsByLikes")]
    // public async Task<IEnumerable<Post>> GetPostsByLikes()
    // {
    //     return await _postService.GetPostsByLikes();
    // }

    // [HttpGet("latest", Name = "GetLatestPosts")]
    // public async Task<IEnumerable<Post>> GetLatestPosts()
    // {
    //     return await _postService.GetLatestPosts();
    // }

    // [HttpGet("mostliked", Name = "GetMostLikedPosts")]
    // public async Task<IEnumerable<Post>> GetMostLikedPosts()
    // {
    //     return await _postService.GetMostLikedPosts();
    // }

    // [HttpPost(Name = "CreatePost")]
    // public async Task CreatePost(Post post)
    // {
    //     await _postService.CreatePost(post);
    // }

    // [HttpPut("update", Name = "UpdatePost")]
    // public async Task<IActionResult> UpdatePost(Post post)
    // {
    //     try
    //     {
    //         await _postService.UpdatePost(post);
    //         return Ok();
    //     }
    //     catch (UserNotFoundException ex)
    //     {
    //         return NotFound(ex.Message);
    //     }
    // }

    // [HttpDelete("delete/{id}", Name = "DeletePost")]
    // public async Task<IActionResult> DeletePost(int id)
    // {
    //     try
    //     {
    //         await _postService.DeletePost(id);
    //         return Ok();
    //     }
    //     catch (UserNotFoundException ex)
    //     {
    //         return NotFound(ex.Message);
    //     }
    // }

    // [HttpGet("comments/{postId}", Name = "GetCommentsByPostId")]
    // public async Task<IEnumerable<Comment>> GetCommentsByPostId(int postId)
    // {
    //     return await _postService.GetCommentsByPostId(postId);
    // }

    // [HttpPost("comment", Name = "CreateComment")]
    // public async Task CreateComment(Comment comment)
    // {
    //     await _postService.CreateComment(comment);
    // }
}