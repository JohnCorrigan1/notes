namespace backend;

public class Post
{
    public int PostId { get; set; }
    public required string Title { get; set; }
    public required string Body { get; set; }
    public DateTime PostedDate { get; set; }
    public List<Comment> Comments { get; set; }
    public int Likes { get; set; }
    public required int AuthorId { get; set; }
}

