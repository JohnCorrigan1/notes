//using System.ComponentModel.DataAnnotations.Schema;
using Postgrest.Attributes;
using Postgrest.Models;

namespace backend;
public class User
{
public int Id { get; set; }
public required string Username { get; set; }
public string Clerk_id { get; set; }
}

[Table("users")]
public class SupaUser : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("username")]
    public string Username { get; set; }

    [Column("clerk_id")]
    public string ClerkId { get; set; }
}