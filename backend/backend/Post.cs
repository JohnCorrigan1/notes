namespace backend;

public class Post
{
    public string body { get; set; }
    public DateTime postedDate { get; set; }
    public List<Comment> comments { get; set; }
    public User author { get; set; }
    public int likes { get; set; }

    public int id { get; set; }
}