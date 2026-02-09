using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public LoginController(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
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

            var accessToken = loginResponse.Token.AccessToken;

            // 🔑 JWT → CLAIMS
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(accessToken);
            var claims = jwtToken.Claims.ToList();

            // 🍪 COOKIE LOGIN
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // 🔐 TOKEN SESSION
            _httpContextAccessor.HttpContext!.Session.SetString("token", accessToken);

            // 🔁 ROLE BASED REDIRECT
            if (claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "Admin"))
               return RedirectToAction("Index", "AdminHome", new { area = "Admin" });

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
