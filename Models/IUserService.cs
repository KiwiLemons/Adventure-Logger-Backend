using System;
namespace AdventureLoggerBackend.Models;

public interface IUserService
{
    bool IsUsernameUnique(string username);
    bool IsEmailUnique(string email);
    void RegisterUser(User user);
    // Other user-related methods...
}
