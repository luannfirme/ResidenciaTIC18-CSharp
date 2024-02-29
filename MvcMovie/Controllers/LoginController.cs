using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MvcMovie.Data;
using MvcMovie.Data.Security;
using MvcMovie.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MvcMovie.Controllers;
public class LoginController : Controller
{
    private readonly MvcMovieContext _context;
    private readonly IConfiguration _configuration;

    public LoginController(MvcMovieContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    // GET: Login/Index
    public IActionResult Index()
    {
        return View();
    }

    // POST: Login/Authenticate
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([Bind("Email,Password")] Login user)
    {
        if (ModelState.IsValid)
        {
            user.Password = Utils.HashPassword(user.Password ?? "");
            var userInDb = await _context.User.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);

            if (userInDb != null)
            {
                var tokenString = GenerateJwtToken(userInDb);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim("Token", tokenString), new Claim(ClaimTypes.Role, userInDb.Name) }, "Cookies")),
                //new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim("Token", tokenString) }, "Cookies")),

                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                });

                return RedirectToAction("Index", "Home");
            }

        }

        TempData["Email"] = user.Email;
        TempData["Mensagem"] = "Usuário não encontrado";

        return RedirectToAction("Index", "Login");
    }

    private string GenerateJwtToken(User user)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
                new Claim(ClaimTypes.Role, user.Name)
            };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }
}
