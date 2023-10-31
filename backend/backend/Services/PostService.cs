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

    public async Task<IEnumerable<PostMetaData>> GetUserPosts(string clerk_id)
    {
        string sql = "select * from postmetadata";

        //return await _context.Connection.QuerytAsync<PostMetaData>(sql, new { clerk_id });
        return await _context.Connection.QueryAsync<PostMetaData>(sql);
    }

    //public async Task CreatePost(PostBody postBody)
    public async Task CreatePost(PostBody post)
    {
        var postData = post.postData;
        var postMetaData = post.postMeta;
        using (var transaction = _context.Connection.BeginTransaction())
        {
            try
            {
                string sql = @"
                INSERT INTO
                    postmetadata (slug, title, postedDate, cover, likes, tags, author_id)
                VALUES
                    (@Slug, @Title, @PostedDate, @Cover, @Likes, @Tags, @AuthorId)";

                await _context.Connection.ExecuteAsync(sql, new
                {
                    Slug = postMetaData.slug,
                    Title = postMetaData.title,
                    PostedDate = DateTime.Now,
                    Cover = postMetaData.cover,
                    Likes = postMetaData.likes,
                    Tags = postMetaData.tags,
                    AuthorId = 1
                }, transaction);

                var lastPostId = await _context.Connection.ExecuteScalarAsync<int>("SELECT last_value FROM postmetadata_id_seq", transaction);

                sql = @"
                INSERT INTO
                    posts (id, date, components)
                VALUES
                    (@Id, @Date, @Components::jsonb)";

                var param = new
                {
                    Id = lastPostId,
                    Date = DateTime.Now,
                    Components = Newtonsoft.Json.JsonConvert.SerializeObject(postData.components)
                };

                await _context.Connection.ExecuteAsync(sql, param, transaction);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
        }
    }
}