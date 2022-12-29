using Microsoft.AspNetCore.Authentication.Negotiate;
using SICCA.Web.Spike.Services;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate(options =>
    {
        options.Events = new NegotiateEvents
        {
            OnAuthenticated = context =>
            {
                // TODO Move this to a different class
                var windowsIdentity = context.Principal.Identity;

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

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddSingleton<StationService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
