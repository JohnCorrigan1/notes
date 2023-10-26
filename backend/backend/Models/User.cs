using System.ComponentModel.DataAnnotations.Schema;
using Postgrest.Attributes;

namespace backend;
public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
}
[Table("users")]
public class SupaUser
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("username")]
    public string Username { get; set; }
}