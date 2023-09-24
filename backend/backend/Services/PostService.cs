using backend.Models;
using Dapper;

namespace backend;

public class PostService : IPostService
{
    public DB _context;

    public PostService(DB context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PostMetaData>> GetPosts()
    {
        return await _context.Connection.QueryAsync<PostMetaData>("SELECT * FROM  postmetadata");
    }

    public async Task<PostQueryResult> GetPost(string slug)
    {
        string sql = @"
        SELECT
            p.id,
            pm.slug,
            pm.title,
            p.components, 
            pm.postedDate,
            pm.likes,
            u.username AS author
        FROM
            postmetadata pm
        INNER JOIN
            posts p ON pm.id = p.id
        INNER JOIN
            users u ON pm.author_id = u.id
        WHERE
            pm.slug = @Slug";

        return await _context.Connection.QueryFirstOrDefaultAsync<PostQueryResult>(sql, new { Slug = slug });
    }

    public async Task CreatePost(Post post, PostMetaData postMetaData)
    {
        string sql = @"
        INSERT INTO
            posts (id, components)
        VALUES
            (@Id, @Components)";

        await _context.Connection.ExecuteAsync(sql, post);

        sql = @"
        INSERT INTO
            postmetadata (id, slug, title, postedDate, cover, likes, tags, author_id)
        VALUES
            (@Id, @Slug, @Title, @PostedDate, @Cover, @Likes, @Tags, @AuthorId)";

        await _context.Connection.ExecuteAsync(sql, postMetaData);
    }
}