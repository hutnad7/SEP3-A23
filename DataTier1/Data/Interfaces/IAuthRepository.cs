using Data.Models;

namespace Data.Interfaces;

public interface IAuthRepository
{
    Task<User> RegisterUserAsync(User user);
    Task<User?> LoginUserAsync(Auth auth);
}