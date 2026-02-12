using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MyProject.Bussines.CQRS.AppUsers.Commands.Response;
using MyProject.DataAccess.Context;
using MyProject.Entity.Entities;
using MyProject.WebUI.Models.UserModel;
using System.ClientModel;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text.Json;

namespace MyProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;

        public LoginController(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UserLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _httpClientFactory.CreateClient("ApiService1");

            var response = await client.PostAsJsonAsync("User/Login", model);
            var raw = await response.Content.ReadAsStringAsync();

            var loginResponse = JsonSerializer.Deserialize<LoginUserCommandResponse>(raw,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // 🔴 Null check ve fallback message
            if (loginResponse == null)
            {
                ModelState.AddModelError("", "Sunucudan geçersiz yanıt alındı.");
                return View(model);
            }

            if (!loginResponse.IsSuccess)
            {
                var errorMessage = string.IsNullOrWhiteSpace(loginResponse.Message)
                                   ? "Kullanıcı adı veya şifre hatalı."
                                   : loginResponse.Message;

                ModelState.AddModelError("", errorMessage);
                return View(model);
            }

            if (loginResponse.Token == null || string.IsNullOrWhiteSpace(loginResponse.Token.AccessToken))
            {
                ModelState.AddModelError("", "Token alınamadı.");
                return View(model);
            }

            // JWT token'dan kullanıcı bilgilerini al
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(loginResponse.Token.AccessToken);

            var userName = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name || c.Type == "unique_name")?.Value;
            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "sub")?.Value;
            var roleName = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName ?? ""),
                new Claim(ClaimTypes.NameIdentifier, userId ?? ""),
                new Claim(ClaimTypes.Role, roleName ?? "")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);

            Response.Cookies.Append("ApiAccessToken",
            loginResponse.Token.AccessToken,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.UtcNow.AddMinutes(60)
            });

            HttpContext.Session.SetString("IsLoggedIn", "true");
            // 🔁 Role-based redirect  
            if (roleName == "Admin")
                return RedirectToAction("Index", "AdminHome", new { area = "Admin" });

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            Response.Cookies.Delete("ApiAccessToken");
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
