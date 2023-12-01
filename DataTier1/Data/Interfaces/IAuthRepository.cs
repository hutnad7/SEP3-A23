using Data.Models;

namespace Data.Interfaces;

public interface IAuthRepository
{
    Task<User> RegisterUserAsync(User user);
    Task<bool> LoginUserAsync(Auth auth);
}