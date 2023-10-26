using Npgsql;
//using Postgrest;

namespace backend.Models;
public class DB
{
    public DB(NpgsqlConnection connection)
    // public DB(Supabase.Client based)
    {
        // Client = based;
        Connection = connection;
    }

    // public Supabase.Client Client { get; }
    public NpgsqlConnection Connection { get; }

}