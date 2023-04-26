using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TirileckWorkshop.Data;
using TirileckWorkshop.Data.Dto;
using TirileckWorkshop.Data.Models;
using TirileckWorkshop.MapperProfiles;
using TirileckWorkshop.Services;
using Microsoft.Extensions.DependencyInjection;
using TirileckWorkshop.Authentication;

var builder = WebApplication.CreateBuilder(args);

// DB
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<EmailConfig>(new EmailConfig()
{
    SmtpAdress = builder.Configuration["EmailConfiguration:SmtpAdress"],
    SmptPort = int.Parse(builder.Configuration["EmailConfiguration:SmptPort"]),
    Login = builder.Configuration["EmailConfiguration:Login"],
    Password = builder.Configuration["EmailConfiguration:Password"],
});
ValidatorsRegistrator.Register(builder.Services);
ServiceRegistrator.Register(builder.Services);
MapperRegistrator.Register(builder.Services);

// Auth
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/adminka/auth";
        options.AccessDeniedPath = "/adminka/auth";
    });
builder.Services.AddAuthorizationCore();



var app = builder.Build();


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();