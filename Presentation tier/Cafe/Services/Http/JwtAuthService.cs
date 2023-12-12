using System.IdentityModel.Tokens.Jwt;
using Blazored.LocalStorage;
using Shared.Dtos;
using Shared.Models;
namespace Cafe.Services.Http;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Text.Json;




public class JwtAuthService : IAuthService
{
    private readonly HttpClient client = new ();
    private ILocalStorageService _localStorage;


    // this private variable for simple caching
    
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;

    public JwtAuthService(ILocalStorageService localStorage)
    {
        this._localStorage = localStorage;
    }
    public async Task LoginAsync(string username, string password)
    {
        UserLoginDto userLoginDto = new()
        {
            Email = username,
            Password = password
        };

        string userAsJson = JsonSerializer.Serialize(userLoginDto);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("http://localhost:8080/api/auth/login", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
        await _localStorage.SetItemAsync("token", responseContent);


        ClaimsPrincipal principal = await CreateClaimsPrincipal();

        OnAuthStateChanged.Invoke(principal);
    }

    private async  Task<ClaimsPrincipal> CreateClaimsPrincipal()
    {
        String Jwt = await _localStorage.GetItemAsStringAsync("token");
        if (string.IsNullOrEmpty(Jwt))
        {
            return new ClaimsPrincipal();
        }

        IEnumerable<Claim> claims = ParseClaimsFromJwt(Jwt);
        
        ClaimsIdentity identity = new(claims, "jwt");

        ClaimsPrincipal principal = new(identity);
        return principal;
    }

    public Task LogoutAsync()
    {
        _localStorage.RemoveItemAsync("token");
        ClaimsPrincipal principal = new();
        OnAuthStateChanged.Invoke(principal);
        return Task.CompletedTask;
    }

    public async Task RegisterAsync(User user)
    {
        string userAsJson = JsonSerializer.Serialize(user);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("http://localhost:8080/api/auth/register", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
    }

    public async Task<string> GetRole(string jwt)
    {
        IEnumerable<Claim> claims = ParseClaimsFromJwt(jwt);
        return claims.First(c => c.Type.Equals("role")).Value;
    }
    public async Task<Guid> GetId(string jwt)
    {
        IEnumerable<Claim> claims = ParseClaimsFromJwt(jwt);
        return Guid.Parse(claims.First(c => c.Type.Equals("id")).Value);
    }
    public async Task<ClaimsPrincipal> GetAuthAsync()
    {
        ClaimsPrincipal principal = await CreateClaimsPrincipal();
        return principal;
    }


    // Below methods stolen from https://github.com/SteveSandersonMS/presentation-2019-06-NDCOslo/blob/master/demos/MissionControl/MissionControl.Client/Util/ServiceExtensions.cs
    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        string payload = jwt.Split('.')[1];
        byte[] jsonBytes = ParseBase64WithoutPadding(payload);
        Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }
}
