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

    //public async Task CreatePost(PostBody postBody)
    public async Task CreatePost(PostBody post)
    {
        var postData = post.postData;
        var postMetaData = post.postMeta;
        try
        {
            string sql = @"
        INSERT INTO
            postmetadata (slug, title, postedDate, cover, likes, tags, author_id)
        VALUES
            (@Slug, @Title, @PostedDate, @Cover, @Likes, @Tags, @AuthorId)";

            await _context.Connection.ExecuteAsync(sql, new { Slug = postMetaData.slug, Title = postMetaData.title, PostedDate = DateTime.Now, Cover = postMetaData.cover, Likes = postMetaData.likes, Tags = postMetaData.tags, AuthorId = 1 });
           // sql = "SELECT LAST_INSERT_ID()";
            //int postId = await _context.Connection.QueryFirstOrDefaultAsync<int>(sql);
            // string componentsJson = postData.components.ToString();
            //var componentsJson = ("components", NpgsqlTypes.NpgsqlDbType.Jsonb);
            //int postMetadataId = await _context.Connection.ExecuteScalarAsync<int>(sql);

            var componentsJson = new Npgsql.NpgsqlParameter("components", NpgsqlTypes.NpgsqlDbType.Jsonb);
            componentsJson.Value = postData.components;
             sql = @"
        INSERT INTO
            posts (date, components)
        VALUES
            (@Date, @Components)";

            await _context.Connection.ExecuteAsync(sql, new { Date = DateTime.Now, Components = componentsJson });

            //get last ID 
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}