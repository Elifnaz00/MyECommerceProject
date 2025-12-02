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
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public AdminHomeController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClient = httpClientFactory.CreateClient("admin");
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
           var dashBoardResponse= await _httpClient.GetAsync(_httpClient.BaseAddress + "/Dashboard/GetDashboardData");

            if (dashBoardResponse.IsSuccessStatusCode)
            {
                var EmpResponse = dashBoardResponse.Content.ReadFromJsonAsync<DashboardViewModel>().Result;
                return View(EmpResponse);
            }
               
            return View();
        }

        public IActionResult Customers()
        {
            return View();
        }


        public IActionResult ActiveOrders()
        {
            return View();
        }

        public IActionResult CancelledOrders()
        {
            return View();
        }


        public IActionResult MailBox()
        {
            return View();
        }


        public IActionResult AvailableProducts()
        {
            return View();
            
        }


        public IActionResult FinishedProducts()
        {
            return View();
        }





    }
}
