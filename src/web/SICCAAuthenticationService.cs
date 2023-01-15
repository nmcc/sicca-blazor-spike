using Microsoft.AspNetCore.Authentication.Negotiate;
using System.Security.Claims;

namespace SICCA.Web.Spike;

internal static class SICCAAuthenticationService
{
    public static void AddSiccaAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            .AddNegotiate(options =>
            {
                options.Events = new NegotiateEvents
                {
                    OnAuthenticated = context =>
                    {
                        // TODO Move this to a different class
                        var windowsIdentity = context.Principal?.Identity;

                        var claims = new List<Claim>();

                        if (windowsIdentity?.Name != null)
                        {
                            claims.Add(new Claim(ClaimTypes.Name, windowsIdentity.Name));
                            claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
                            claims.Add(new Claim(ClaimTypes.Role, "Operador estação"));
                        }

                        var identity = new ClaimsIdentity(claims, "Windows");
                        var user = new ClaimsPrincipal(identity);

                        context.Principal = user;

                        return Task.CompletedTask;
                    }
                };
            });
    }
}
