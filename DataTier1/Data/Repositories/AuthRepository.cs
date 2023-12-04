using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly DBContext _context;

    public AuthRepository(DBContext context)
    {
        _context = context;
    }
    
    public async Task<User> RegisterUserAsync(User user)
    {
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ArgumentNullException(e.Message);
        }
    }

    public async Task<User> LoginUserAsync(Auth auth)
    {
        try
        {
            User? foundUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == auth.Email);

            if (foundUser == null)
            {
                throw new Exception("User not found");
            }

            return foundUser;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}