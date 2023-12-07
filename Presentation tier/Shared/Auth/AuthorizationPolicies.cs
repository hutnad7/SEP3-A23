
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Auth;

public static class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("MustBeCafeOwner", a =>
                a.RequireAuthenticatedUser().RequireClaim("Role", "CafeOwner"));
            
            options.AddPolicy("MustBeEntertainer", a =>
                a.RequireAuthenticatedUser().RequireClaim("Role", "Entertainer"));

            options.AddPolicy("MustBeUser", a =>
                a.RequireAuthenticatedUser().RequireClaim("Role", "User"));
        });
    }
}