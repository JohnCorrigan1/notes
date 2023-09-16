using Npgsql;

namespace backend.Models;
public class DB
{
    public DB(NpgsqlConnection connection)
    {
        Connection = connection;
    }

    public NpgsqlConnection Connection { get; }
}