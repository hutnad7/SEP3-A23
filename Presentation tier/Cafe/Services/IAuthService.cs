using System.Security.Claims;
using Shared.Models;

namespace Cafe.Services;

public interface IAuthService
{
    public Task LoginAsync(string username, string password);
    public Task LogoutAsync();
    public Task RegisterAsync(User user);
    public Task<ClaimsPrincipal> GetAuthAsync();

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    public Task<string> GetRole(string jwt);
    public Task<Guid> GetId(string jwt);


}