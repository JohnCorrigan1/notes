namespace backend;

public interface IPostService
{
    Task<IEnumerable<Post>> GetPosts();
    Task<Post> GetPostByPostId(int id);
    Task<IEnumerable<Post>> GetPostsByUserId(int userId);
    Task<IEnumerable<Post>> GetPostsByDate();
    Task<IEnumerable<Post>> GetPostsByLikes();
    Task<IEnumerable<Post>> GetLatestPosts();
    Task<IEnumerable<Post>> GetMostLikedPosts();
    Task CreatePost(Post post);
    Task UpdatePost(Post post);
    Task DeletePost(int id);
    Task<IEnumerable<Comment>> GetCommentsByPostId(int postId);
    Task CreateComment(Comment comment);
}