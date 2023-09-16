using backend.Models;
using backend.Exceptions;
using Dapper;

namespace backend;

public class UserService : IUserService
{
    public DB _context;

    public UserService(DB context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _context.Connection.QueryAsync<User>("SELECT * FROM users");
    }

    public async Task<User> GetUser(int id)
    {
        var sql = "SELECT * FROM users WHERE id = @id";
        var user = await _context.Connection.QueryFirstOrDefaultAsync<User>(sql, new { id = id }) ?? throw new UserNotFoundException("User not found");
        return user;
    }

    public async Task CreateUser(string username)
    {
        var sql = "INSERT INTO users (username) VALUES (@username) RETURNING id";
        await _context.Connection.ExecuteAsync(sql, new { username = username });

    }

    public async Task UpdateUser(User user)
    {
        var sql = "UPDATE users SET username = @username WHERE id = @id RETURNING id";
        var id = await _context.Connection.ExecuteAsync(sql, new { username = user.Username, id = user.Id });
        if (id == 0)
        {
            throw new UserNotFoundException("User not found");
        }
    }

    public async Task DeleteUser(int id)
    {
        var sql = "DELETE FROM users WHERE id = @id RETURNING id";
        var user = await _context.Connection.ExecuteAsync(sql, new { id = id });
        if (user == 0)
        {
            throw new UserNotFoundException("User not found");
        }
    }
}