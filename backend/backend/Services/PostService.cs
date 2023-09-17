using backend.Models;
using backend.Exceptions;
using Dapper;

namespace backend;

public class PostService : IPostService
{
    public DB _context;

    public PostService(DB context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Post>> GetPosts()
    {
        var posts = await _context.Connection.QueryAsync<Post>("SELECT * FROM posts");
        foreach(Post post in posts)
        {
            Console.WriteLine(post.Post_Id);
	    }
        //return await _context.Connection.QueryAsync<Post>("SELECT * FROM posts");
        return posts;
    }

    public async Task<Post> GetPostByPostId(int id)
    {
        var sql = "SELECT * FROM posts WHERE post_id = @post_id";
        var posts = await _context.Connection.QueryFirstOrDefaultAsync<Post>(sql, new { post_id = id }) ?? throw new UserNotFoundException("Post not found");
        return posts;
    }

    public async Task<IEnumerable<Post>> GetPostsByUserId(int userId)
    {
        var sql = "SELECT * FROM posts WHERE user_id = @user_id";
        var posts = await _context.Connection.QueryAsync<Post>(sql, new { user_id = userId }) ?? throw new UserNotFoundException("Post not found");
        return posts;
    }

    public async Task<IEnumerable<Post>> GetPostsByDate()
    {
        var sql = "SELECT * FROM posts ORDER BY PostedDate DESC";
        var posts = await _context.Connection.QueryAsync<Post>(sql) ?? throw new UserNotFoundException("Posts not found");
        return posts;
    }

    public async Task<IEnumerable<Post>> GetPostsByLikes()
    {
        var sql = "SELECT * FROM posts ORDER BY Likes";
        var posts = await _context.Connection.QueryAsync<Post>(sql) ?? throw new UserNotFoundException("Posts not found");
        return posts;
    }

    public async Task<IEnumerable<Post>> GetLatestPosts()
    {
        var sql = "SELECT * FROM posts ORDER BY PostedDate DESC LIMIT 5";
        var posts = await _context.Connection.QueryAsync<Post>(sql) ?? throw new UserNotFoundException("Posts not found");
        return posts;
    }

    public async Task<IEnumerable<Post>> GetMostLikedPosts()
    {
        var sql = "SELECT * FROM posts ORDER BY Likes DESC LIMIT 5";
        var posts = await _context.Connection.QueryAsync<Post>(sql) ?? throw new UserNotFoundException("Posts not found");
        return posts;
    }

    public async Task CreatePost(Post post)
    {
        var sql = "INSERT INTO posts (post_id, title, body, posted_date, likes, author_id) VALUES (@post_id, @title, @body, @posted_date, @likes, @author_id) RETURNING post_id";
        await _context.Connection.ExecuteAsync(sql, new { post_id = post.Post_Id, title = post.Title, body = post.Body, posted_date = post.Posted_Date, likes = post.Likes, author_id = post.Author_Id });
    }

    public async Task UpdatePost(Post post)
    {
        var sql = "UPDATE posts SET title = @title, body = @body, posted_date = @posted_date, likes = @likes, author_id = @author_id";
        var id = await _context.Connection.ExecuteAsync(sql, new { title = post.Title, body = post.Body, posted_date = post.Posted_Date, likes = post.Likes, author_id = post.Author_Id });
        if (id == 0)
        {
            throw new UserNotFoundException("Post not found");
        }
    }

    public async Task DeletePost(int id)
    {
        var sql = "DELETE FROM posts WHERE post_id = @post_id RETURNING post_id";
        var post = await _context.Connection.ExecuteAsync(sql, new { post_id = id });
        if (post == 0)
        {
            throw new UserNotFoundException("Post not found");
        }
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPostId(int postId)
    {
        var sql = "SELECT * FROM comments WHERE post_id = @post_id";
        var comments = await _context.Connection.QueryAsync<Comment>(sql, new { post_id = postId }) ?? throw new UserNotFoundException("Comments not found");
        return comments;
    }

    public async Task CreateComment(Comment comment)
    {
        var sql = "INSERT INTO comments (id, body, posted_date, likes, user_id, post_id) VALUES (@id, @body, @posted_date, @likes, @user_id, @post_id)";
        await _context.Connection.ExecuteAsync(sql, new { id = comment.Id, body = comment.Body, posted_date = comment.Posted_Date, likes = comment.Likes, user_id = comment.User_Id, post_id = comment.Post_Id });
    }

}