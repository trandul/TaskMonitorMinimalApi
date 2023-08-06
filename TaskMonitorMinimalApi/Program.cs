using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel;
using Microsoft.EntityFrameworkCore;
using TaskMonitorMinimalApi.DA.EF;
using TaskMonitorMinimalApi.DA.Interfaces;
using TaskMonitorMinimalApi.DA.Repositories;
using Microsoft.AspNetCore.Mvc;
using TaskMonitorMinimalApi.Enums;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using TaskMonitorMinimalApi.DTO;
using TaskMonitorMinimalApi.Endpoints;

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
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<JobsRepository>();
builder.Services.AddScoped<AuthRepository>();
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

app.MapGet("/", () => Results.Redirect("/swagger"));



AuthEndpoints.Map(app);
UserEndpoints.Map(app);
JobEndpoints.Map(app);




app.Run();
