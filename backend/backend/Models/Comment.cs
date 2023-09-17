namespace backend;

public class Comment
{
    public int Id { get; set; }
    public int Post_Id { get; set; }
    public int User_Id { get; set; }
    public required string Body { get; set; }
    public int Likes { get; set; }
    public DateTime Posted_Date = new();
}