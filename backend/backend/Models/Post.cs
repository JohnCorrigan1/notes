using Postgrest.Attributes;
using Postgrest.Models;
using Newtonsoft.Json.Linq;

namespace backend;

public class Post
{
    public int id { get; set; }
    public DateTime date { get; set; }
    public string components { get; set; }
}
public class PostData
{
    public string title { get; set; }
    public string date { get; set; }
    public string author { get; set; }
    public string cover { get; set; }
    public JArray components { get; set; }
}
public class PostBody
{
    public PostMeta postMeta { get; set; }
    public PostData postData { get; set; }
}

public class PostMeta
{
    public string slug { get; set; }
    public string title { get; set; }
    public string postedDate { get; set; }
    public string cover { get; set; }
    public int likes { get; set; }
    public string author { get; set; }
    public string[] tags { get; set; }
    public bool live { get; set; }
}

public class PostMetaData
{
    public int id { get; set; }
    public string slug { get; set; }
    public string title { get; set; }
    public string postedDate { get; set; }
    public string cover { get; set; }
    public string likes { get; set; }
    public string[] tags { get; set; }
    public int authorId { get; set; }
    public bool live { get; set; }
}

public class PostQueryResult
{
    public int Id { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public string components { get; set; }
    public DateTime PostedDate { get; set; }
    public int Likes { get; set; }
    public string Author { get; set; }
}

public class EditPostData 
{
    public string slug { get; set; }
    public string title { get; set; }
    public string posteddate { get; set; }
    public string cover { get; set; }
    public int likes { get; set; }
    public bool live { get; set; }
    public string[] tags { get; set; }
    public string username { get; set; }  
    public JArray components { get; set; }
}

public class EditPostDataStr
{
    public string slug { get; set; }
    public string title { get; set; }
    public string posteddate { get; set; }
    public string cover { get; set; }
    public int likes { get; set; }
    public bool live { get; set; }
    public string[] tags { get; set; }
    public string username { get; set; }
    public string components { get; set; }
}