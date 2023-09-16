namespace backend;

public class Comment
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    public required string Body { get; set; }
    public int Likes { get; set; }
    public DateTime PostedDate = new();
}