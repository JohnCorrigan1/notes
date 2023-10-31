namespace backend;

public interface IPostService
{
    Task<IEnumerable<PostMetaData>> GetPosts();
    Task<IEnumerable<PostMetaData>> GetUserPosts(string clerk_id);
    Task<PostQueryResult> GetPost(string slug);
    Task CreatePost(PostBody post);
}