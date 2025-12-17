using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.DTO.DTOs.AdminDTOs.ProductDto;
using MyProject.DTO.DTOs.OrderDTOs;
using MyProject.Entity.Entities;
using MyProject.WebUI.Models.AdminModel.DashboardModel;
using MyProject.WebUI.Models.AdminModel.OrderModel;
using MyProject.WebUI.Models.AdminModel.ProductModel;
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
                var activeOrderList  = await activeOrderResponse.Content.ReadFromJsonAsync<GetActiveOrderListDto>();
                if (activeOrderList == null)
                {
                    return View(new ActiveOrderViewModel());
                }

                var activeOrderListVm = new ActiveOrderViewModel
                {
                    Orders = _mapper.Map<List<OrderListModel>>(activeOrderList.OrderListDtos),
                    OrderStatuses = _mapper.Map<List<OrderStatusViewModel>>(activeOrderList.OrderStatusDtos)
                };
                return View(activeOrderListVm);
            }
            return View();
        }

        public async Task<IActionResult> CancelledOrders()
        {
            var cancelledOrderResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + "/Order/admin-get-cancelled-orderlist");
            if(cancelledOrderResponse.IsSuccessStatusCode)
            {
                var cancelledOrderList = await cancelledOrderResponse.Content.ReadFromJsonAsync<List<OrderListDto>>();
                var cancelledOrderListVm = _mapper.Map<List<OrderListModel>>(cancelledOrderList);
                return View(cancelledOrderListVm);
            }   
            return View();
        }


        public IActionResult MailBox()
        {
            return View();
        }


        public async Task<IActionResult> AvailableProducts()
        {
            var availableProductsResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + "/Product/get-avaiable-product-list");
            if (availableProductsResponse.IsSuccessStatusCode)
            {
                var availableProductList = await availableProductsResponse.Content.ReadFromJsonAsync<List<ProductListDto>>();
                var cancelledOrderListVm = _mapper.Map<List<ProductListViewModel>>(availableProductList);
                return View(cancelledOrderListVm);
            }
            return View();
            
        }


        public IActionResult FinishedProducts()
        {
            return View();
        }
    }
}
