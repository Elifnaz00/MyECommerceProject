using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MyProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BaseAdminController : Controller
    {
        protected readonly HttpClient _httpClient;
        protected readonly IHttpContextAccessor _contextAccessor;
        protected readonly IHttpClientFactory _httpClientFactory;

        protected BaseAdminController(HttpClient httpClient, IHttpContextAccessor contextAccessor, IHttpClientFactory httpClientFactory)
        {
            _contextAccessor = contextAccessor;

            _httpClientFactory = httpClientFactory;

        }

        protected HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient("admin");

            var token = HttpContext.Request.Cookies["ApiAccessToken"];

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            return client;
        }
    }
    }
