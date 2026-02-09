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
        protected readonly IHttpClientFactory  _httpClientFactory;

        protected BaseAdminController(HttpClient httpClient,IHttpContextAccessor contextAccessor, IHttpClientFactory httpClientFactory)
        {
            _contextAccessor = contextAccessor;

            _httpClient = httpClientFactory.CreateClient("admin");

            var token = _contextAccessor.HttpContext?.Session.GetString("token");

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }


        }
    }
}
