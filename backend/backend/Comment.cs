namespace backend;

public class Comment
{
    public User user { get; set; }
    public string body { get; set; }
    public DateTime postedDate { get; set; }
}