using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MyProject.DataAccess.Context;
using MyProject.Entity.Entities;
using MyProject.WebUI.Models.UserModel;
using System.ClientModel;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace MyProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager; 
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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
        public async Task<IActionResult> Index(UserLoginViewModel userLoginViewModel)
        {
            if(!ModelState.IsValid)
                return View(userLoginViewModel);

            
             HttpClient client = _httpClientFactory.CreateClient("ApiService1");

             var response = await client.PostAsJsonAsync(client.BaseAddress + "/User/Login", userLoginViewModel);

            if (response.IsSuccessStatusCode)
            {
                
                var signAppUser = await _userManager.FindByNameAsync(userLoginViewModel.UserName);
                if (signAppUser != null)
                {
                    await _signInManager.SignInAsync(signAppUser, isPersistent: false);
                    string userToken= await response.Content.ReadAsStringAsync();

                    // Token'dan claim'leri al
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(userToken);

                    var claims = token.Claims.ToList();

                    // Cookie Authentication için identity oluştur
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    // Kullanıcıyı cookie ile login et
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                 
                    // Token'ı session'da tut (API isteklerinde kullanılabilir)
                    _httpContextAccessor?.HttpContext?.Session.SetString("token", userToken);
                }
                return RedirectToAction("Index", "Home");
            }

            else
                {

                string apiResponseMessage = await response.Content.ReadAsStringAsync();

                ModelState.AddModelError(string.Empty, apiResponseMessage);
                    return View(userLoginViewModel);
                }}



        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }



        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModeL userRegisterViewModel)
        {
            if (!ModelState.IsValid)
                return View(userRegisterViewModel);
               

                HttpClient client = _httpClientFactory.CreateClient("ApiService1");

                var response = await client.PostAsJsonAsync(client.BaseAddress + "/User/Register", userRegisterViewModel);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Success = "Kayıt işlemi başarılı. Giriş yapabilirsiniz.";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    string errorMessage= await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Kayıt işlemi başarısız: {errorMessage}");
            }
            
            return View(userRegisterViewModel);}


        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            HttpClient client = _httpClientFactory.CreateClient("ApiService1");
            var response = await client.PostAsync(client.BaseAddress + "/User/Logout", null);

            if(response.IsSuccessStatusCode)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Çıkış işlemi başarısız: {errorMessage}");

            }
            return RedirectToAction("Index", "Login");
        }
    }
}
