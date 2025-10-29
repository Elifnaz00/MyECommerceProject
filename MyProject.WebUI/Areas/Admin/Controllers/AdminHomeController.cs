using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.WebUI.Models.AdminModel.DashboardModel;
using Newtonsoft.Json;

namespace MyProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public AdminHomeController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClient = httpClientFactory.CreateClient("admin");
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

      
    }
}
