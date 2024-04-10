// UserService.cs
using AdventureLoggerBackend.Models;
using System.Linq;
using AdventureLoggerBackend.Data;

namespace AdventureLoggerBackend.Models;

public class UserService : IUserService
{
    private readonly AdventureLoggerBackendContext _dbContext; // Assuming you have a DbContext for database access

    public UserService(AdventureLoggerBackendContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool IsUsernameUnique(string username)
    {
        // Check if any user in the database already has the provided username
        return !_dbContext.User.Any(u => u.UserName == username);
    }

    public bool IsEmailUnique(string email)
    {
        // Check if any user in the database already has the provided email
        return !_dbContext.User.Any(u => u.Email == email);
    }

    public void RegisterUser(User user)
    {
        _dbContext.User.Add(user);
        _dbContext.SaveChanges();
    }
}
