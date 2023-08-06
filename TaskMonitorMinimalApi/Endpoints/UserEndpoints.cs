using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskMonitorMinimalApi.DA.Repositories;
using TaskMonitorMinimalApi.DTO;

namespace TaskMonitorMinimalApi.Endpoints
{
    public static class UserEndpoints
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/User", [Authorize(Roles = "Admin,Manager, User")] async ([FromServices] UserRepository db) =>
            {
                return Results.Json(db.GetAll());
            });

            app.MapGet("/api/User{login}", [Authorize(Roles = "Admin,Manager, User")] async (string login, [FromServices] UserRepository db) =>
            {
                return Results.Json(db.GetByLogin(login));
            });

            app.MapDelete("/api/User{login}", [Authorize(Roles = "Admin,Manager, User")] async (string login, [FromServices] UserRepository db) =>
            {
                db.Delete(login);
            });

            app.MapPut("/api/User", [Authorize(Roles = "Admin,Manager, User")] async (UserRegisterDTO user, [FromServices] UserRepository db) =>
            {
                db.Update(user);
            });

            app.MapPost("/api/User/{login}/Role", [Authorize(Roles = "Admin")] async (string login, string role, [FromServices] UserRepository db) =>
            {
                db.SetRole(login, role);
            });
            app.MapPost("/api/User/{login}/Jobs", [Authorize(Roles = "Admin, Manager")] async (string login, Guid JobId, [FromServices] UserRepository db) =>
            {
                db.AddJob(login, JobId);
            });
        }
    }
}
