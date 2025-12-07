using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Entity.Entities;
using MyProject.WebUI.Models.AdminModel.DashboardModel;
using MyProject.WebUI.Models.OrderModel;
using MyProject.WebUI.Models.UserModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

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
                var EmpResponse = await dashBoardResponse.Content.ReadFromJsonAsync<DashboardViewModel>();
                return View(EmpResponse);
            }
               
            return View();
        }

        public async Task<IActionResult> Customers()
        {
            var dashBoardResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + "/User/admin-get-userlist");
            dashBoardResponse.EnsureSuccessStatusCode();
           
            if (dashBoardResponse.IsSuccessStatusCode)
            {
                var EmpResponse =   await dashBoardResponse.Content.ReadAsStringAsync();
                var customerList = JsonConvert.DeserializeObject<List<CustomerListViewModel>>(EmpResponse);

                return View(customerList);
            }
            return View();

        }


        public async Task<IActionResult> ActiveOrders()
        {
            var activeOrderResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + "/Order/admin-get-active-orderlist");
            if(activeOrderResponse.IsSuccessStatusCode)
            {
                var empResponse = await activeOrderResponse.Content.ReadAsStringAsync();
                var activeOrderList = JsonConvert.DeserializeObject<List<StateOrderModel>>(empResponse);
                return View(activeOrderList);
            }
            return View();
        }

        public async Task<IActionResult> CancelledOrders()
        {
            var cancelledOrderResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + "/Order/admin-get-cancelled-orderlist");
            if(cancelledOrderResponse.IsSuccessStatusCode)
            {
                var empResponse = await cancelledOrderResponse.Content.ReadAsStringAsync();
                var cancelledOrderList = JsonConvert.DeserializeObject<List<StateOrderModel>>(empResponse);
                return View(cancelledOrderList);
            }   
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
