using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel;
using Microsoft.EntityFrameworkCore;
using TaskMonitorMinimalApi.DA.EF;
using TaskMonitorMinimalApi.Models;
using TaskMonitorMinimalApi.DA.Interfaces;
using TaskMonitorMinimalApi.DA.Repositories;
using Microsoft.AspNetCore.Mvc;
using TaskMonitorMinimalApi.Enums;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = builder.Environment.ApplicationName,
        Version = "v1"
    });
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ObjectivesRepository>();
builder.Services.AddScoped<UserRepository>();
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                                    $"{builder.Environment.ApplicationName} v1"));
}

app.MapGet("/swag", () => "Hello Swagger!");

app.MapGet("/", () => "Hello World!");





app.MapPost("/api/login", async (string? returnUrl, HttpContext context) =>
{

});
app.MapPost("/api/register", async (string username, string password, [FromServices] UserRepository db) =>
{
    db.Register(username, password);
});
app.MapPost("/api/logout", async (string? returnUrl, HttpContext context) =>
{
    context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Ok();
});

app.MapGet("/api/Task", async ([FromServices] ObjectivesRepository db) =>
{
    return Results.Json(db.GetAll());
});
app.MapPost("/api/Task", async (ObjectiveCreate objective, [FromServices] ObjectivesRepository db) =>
{
    db.Add(objective);
});
app.Run();
