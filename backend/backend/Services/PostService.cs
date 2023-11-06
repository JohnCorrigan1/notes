using System.Transactions;
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
        return await _context.Connection.QueryAsync<PostMetaData>("SELECT * FROM  postmetadata where live = true");
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
            pm.slug = @Slug and pm.live = true";

        return await _context.Connection.QueryFirstOrDefaultAsync<PostQueryResult>(sql, new { Slug = slug });
    }

    public async Task<PostQueryResult> PreviewPost(string clerk_id, string slug)
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
            pm.slug = @Slug and u.clerk_id = @Clerk_Id";

        return await _context.Connection.QueryFirstOrDefaultAsync<PostQueryResult>(sql, new { Slug = slug, Clerk_Id = clerk_id });
    }

    public async Task<EditPostDataStr> EditPostData(string clerk_id, string slug)
    {
        string sql = @"
        select
            pm.slug,
            pm.title,
            pm.posteddate,
            pm.cover,
            pm.likes,
            pm.live,
            pm.tags,
            u.username,
            p.components
        from 
            postmetadata pm
        JOIN 
            posts p ON pm.id = p.id
        INNER join
            users u ON pm.author_id = u.id
        WHERE 
            u.clerk_id = @Clerk_Id and pm.slug = @Slug";

        return await _context.Connection.QueryFirstOrDefaultAsync<EditPostDataStr>(sql, new { Slug = slug, Clerk_Id = clerk_id });
    }    

    public async Task<IEnumerable<PostMetaData>> GetUserPosts(string clerk_id)
    {
        string sql = @"
	    SELECT * from
            postmetadata pm
        INNER JOIN
            users u ON pm.author_id = u.id
        WHERE
            u.clerk_id = @Clerk_Id";

        return await _context.Connection.QueryAsync<PostMetaData>(sql, new { Clerk_Id = clerk_id });
    }

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

    public async Task UpdatePost(string clerk_id, string slug, EditPostData postData)
    {

        Console.WriteLine("slug: ", postData.slug);
        using (var scope = new TransactionScope())
        {
            // Update postmetadata table
            string sql1 = @"
        UPDATE postmetadata 
        SET 
            slug = @NewSlug,
            title = @NewTitle,
            posteddate = @NewPostedDate,
            cover = @NewCover,
            likes = @NewLikes,
            live = @NewLive,
            tags = @NewTags
        WHERE 
            author_id = (SELECT id FROM users WHERE clerk_id = @ClerkId) 
            AND slug = @OldSlug";
            await _context.Connection.ExecuteAsync(sql1, new
            {
                NewSlug = postData.slug,
                NewTitle = postData.title,
                NewPostedDate = DateTime.Now,
                NewCover = postData.cover,
                NewLikes = postData.likes,
                NewLive = postData.live,
                NewTags = postData.tags,
                ClerkId = clerk_id,
                OldSlug = slug 
            });

            // Update posts table
            string sql2 = "UPDATE posts SET components = @NewComponents::jsonb WHERE id = (SELECT id FROM postmetadata WHERE slug = @OldSlug)";
            await _context.Connection.ExecuteAsync(sql2, new { NewComponents = Newtonsoft.Json.JsonConvert.SerializeObject(postData.components), OldSlug = slug });

            scope.Complete();
        }
        //   string sql = @"
        //   UPDATE 
        //       postmetadata pm 
        //   JOIN 
        //       users u ON u.id = pm.author_id 
        //   JOIN
        //       posts p ON p.id = pm.id
        //   SET
        //       pm.slug = @NewSlug,
        //       pm.title = @NewTitle,
        //       pm.posteddate = @NewPostedDate,
        //       pm.cover = @NewCover,
        //       pm.likes = @NewLikes,
        //       pm.live = @NewLive,
        //       pm.tags = @NewTags,
        //       p.components = @NewComponents
        //   WHERE 
        //       u.clerk_id = @ClerkId and pm.slug = @OldSlug
        //";

        //   await _context.Connection.ExecuteAsync(sql, new
        //   {
        //       NewSlug = postData.slug,
        //       NewTitle = postData.title,
        //       NewPostedDate = postData.posteddate,
        //       NewCover = postData.cover,
        //       NewLikes = postData.likes,
        //       NewLive = postData.live,
        //       NewTags = postData.tags,
        //       NewComponents = Newtonsoft.Json.JsonConvert.SerializeObject(postData.components),
        //       ClerkId = clerk_id,
        //       OldSlug = slug
        //   });
        //return Ok();
    }
}