using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("user/{clerk_id}", Name = "GetUserPosts")]
    public async Task<IEnumerable<PostMetaData>> GetUserPosts(string clerk_id) 
    {
        return await _postService.GetUserPosts(clerk_id); 
    }

    [HttpGet("preview/{clerk_id}/{slug}", Name = "PreviewPost")]
    public async Task<IActionResult> PreviewPost(string clerk_id, string slug)
    {
        return await _postService.PreviewPost(clerk_id, slug) switch
        {
            PostQueryResult post => Ok(post),
            _ => NotFound()
        };
    }

    [HttpGet("edit/{clerk_id}/{slug}", Name = "EditPost")]
    public async Task<IActionResult> EditPost(string clerk_id, string slug)
    {
        return await _postService.EditPostData(clerk_id, slug); 
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
            return NotFound(e.Message);
        }

    }
}
