namespace backend;
public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(int id);
    Task CreateUser(string username);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
}