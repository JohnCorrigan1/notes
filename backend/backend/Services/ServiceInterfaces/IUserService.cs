namespace backend;
public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(string clerkId);
    Task CreateUser(string username, string clerkId);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
}