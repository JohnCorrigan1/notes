namespace backend;

public class Post
{
    public int id { get; set; }
    public DateTime date { get; set; }
    public string components { get; set; }
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