using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using TirileckWorkshop.Data;
using TirileckWorkshop.Data.Dto;
using TirileckWorkshop.Data.Models;

namespace TirileckWorkshop.Services;

public class AuthentificationService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _manager;
    
    public AuthentificationService(ApplicationDbContext context, UserManager<User> manager, AuthentificationService service)
    {
        _context = context;
        _manager = manager;
    }

    // public async Task<bool> Login(LoginUserDto model)
    // {
    //     var user = _context.Users.FirstOrDefault(x => x.Email == model.Login && x.Password == model.Password);
    //     if (user == default)
    //     {
    //         return false;
    //     }
    //     await Authenticate(user); // аутентификация
    //     return true;
    // }
    //
    // private async Task Authenticate(User user)
    // {
    //     // создаем один claim
    //     var claims = new List<Claim>
    //     {
    //         new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
    //         new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
    //     };
    //     // создаем объект ClaimsIdentity
    //     ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
    //         ClaimsIdentity.DefaultRoleClaimType);
    //     // установка аутентификационных куки
    //     _manager.
    //     await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    // }
}