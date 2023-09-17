namespace backend;

public class Post
{
    public int Post_Id { get; set; }
    public required string Title { get; set; }
    public required string Body { get; set; }
    public DateTime Posted_Date { get; set; }
    public int Likes { get; set; }
    public required int Author_Id { get; set; }
}
