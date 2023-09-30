namespace backend;

public interface IPostService
{
    Task<IEnumerable<PostMetaData>> GetPosts();
    Task<PostQueryResult> GetPost(string slug);
    Task CreatePost(PostBody post);
}