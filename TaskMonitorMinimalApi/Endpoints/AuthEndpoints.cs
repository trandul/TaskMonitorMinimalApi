using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using TaskMonitorMinimalApi.DA.Repositories;
using TaskMonitorMinimalApi.DTO;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace TaskMonitorMinimalApi.Endpoints
{
    public static class AuthEndpoints
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/api/login", async (string login, string password, HttpContext context, [FromServices] AuthRepository db) =>
            {

                var user = db.Login(login, password);
                if (user == null)
                {
                    return Results.Unauthorized();
                }
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimTypes.Role, user.Role)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await context.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(1),
                    });
                return Results.Ok(user);
            });
            app.MapPost("/api/register", async (UserRegisterDTO userRegister, [FromServices] AuthRepository db) =>
            {
                return db.Register(userRegister);
            });
            app.MapPost("/api/logout", async (string? returnUrl, HttpContext context) =>
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Results.Ok();
            });

        }
    }
}
