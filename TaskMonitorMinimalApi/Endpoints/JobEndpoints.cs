using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskMonitorMinimalApi.DA.Repositories;
using TaskMonitorMinimalApi.DTO;

namespace TaskMonitorMinimalApi.Endpoints
{
    public static class JobEndpoints
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/Task", [Authorize(Roles = "Admin, Manager, User")] async ([FromServices] JobsRepository db) =>
            {
                return Results.Json( await db.GetAll());
            });
            app.MapPost("/api/Task", [Authorize(Roles = "Admin, Manager")] async (JobCreateDTO job, HttpContext context, [FromServices] JobsRepository db) =>
            {
                job.ManagerLogin = context.User.Identity.Name;
                await db.Add(job);
            });
            app.MapPut("/api/Task", [Authorize(Roles = "Admin, Manager")] async (JobUpdateDTO job, HttpContext context, [FromServices] JobsRepository db) =>
            {
                await db.Update(job);
            });
        }
    }
}
