using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Security.Principal;

namespace SICCA.Web.Spike.Authorization;

public class WindowsAuthStateProvider : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // TODO Read roles from database
#pragma warning disable CA1416 // Validate platform compatibility
        var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, WindowsIdentity.GetCurrent().Name),
                //new Claim(ClaimTypes.Role, "Administrator"),
                new Claim(ClaimTypes.Role, "Operador Estação")
            }, "Windows");
#pragma warning restore CA1416 // Validate platform compatibility

        var user = new ClaimsPrincipal(identity);
        return await Task.FromResult(new AuthenticationState(user));
    }
}