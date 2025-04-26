using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using AutomobiliuPardavimoPrograma.Services;
using AutomobiliuPardavimoPrograma.Models;

namespace AutomobiliuPardavimoPrograma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.AuthenticateAsync(request.Email, request.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.ElPastas),
                new Claim("Vardas", user.Vardas),
                new Claim(ClaimTypes.Role, user.YraAdmin ? "Admin" : "User")
            };
                        foreach (var claim in claims)
            {
                Console.WriteLine($"Claim type: {claim.Type}, value: {claim.Value}");
            }

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);
            Console.WriteLine(claims);

            await HttpContext.SignInAsync("Cookies", principal);
            Console.WriteLine("Vartotojas sėkmingai prisijungė ir sukūrė cookies.");

            return Ok(new { message = "Login successful" });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { message = "Logged out" });
        }

        [HttpGet("whoami")]
        public IActionResult WhoAmI()
        {
            return Ok(new
            {
                User.Identity?.IsAuthenticated,
                User.Identity?.Name,
                Claims = User.Claims.Select(c => new { c.Type, c.Value })
            });
        }

    }


    public class LoginRequest
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
