using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.DTO.DTOs.AdminDTOs.ProductDto;
using MyProject.DTO.DTOs.AdminDTOs.UserDto;
using MyProject.DTO.DTOs.OrderDTOs;
using MyProject.Entity.Entities;
using MyProject.WebUI.Models.AdminModel.DashboardModel;
using MyProject.WebUI.Models.AdminModel.OrderModel;
using MyProject.WebUI.Models.AdminModel.ProductModel;
using MyProject.WebUI.Models.AdminModel.UserModel;
using MyProject.WebUI.Models.UserModel;
using Newtonsoft.Json;
using System.Collections.Generic;
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
            var dashBoardResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + "/Dashboard/GetDashboardData");

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
                var dtoList = await dashBoardResponse.Content.ReadFromJsonAsync<List<UserListDto>>();

                var vmList = _mapper.Map<List<CustomerListViewModel>>(dtoList);

                return View(vmList);
            }
            return View();

        }



        public async Task<IActionResult> ActiveOrders()
        {
            var activeOrderResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + "/Order/admin-get-active-orderlist");
            if (activeOrderResponse.IsSuccessStatusCode)
            {
                var activeOrderList = await activeOrderResponse.Content.ReadFromJsonAsync<GetActiveOrderListDto>();
                if (activeOrderList is null)
                {
                    return View(new ActiveOrderViewModel());
                }
                var activeOrderListVM = new ActiveOrderViewModel()
                {
                    Orders = _mapper.Map<List<OrderListModel>>(activeOrderList.Orders),
                    OrderStatuses = _mapper.Map<List<OrderStatusViewModel>>(activeOrderList.OrderStatuses)
                };

                return View(activeOrderListVM);
            }
            return View();
        }




        public async Task<IActionResult> CancelledOrders()
        {
            var cancelledOrderResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + "/Order/admin-get-cancelled-orderlist");
            if (cancelledOrderResponse.IsSuccessStatusCode)
            {
                var cancelledOrderList = await cancelledOrderResponse.Content.ReadFromJsonAsync<List<OrderListDto>>();
                var cancelledOrderListVM = _mapper.Map<List<OrderListModel>>(cancelledOrderList);
                return View(cancelledOrderListVM);
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
                var availableProductListVm = _mapper.Map<List<ProductListViewModel>>(availableProductList);
                return View(availableProductListVm);
            }
            return View();

        }


 
        public async Task<IActionResult> FinishedProducts()
        {
            var finishedProductsResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + "/Product/get-finished-product-list");
            if (finishedProductsResponse.IsSuccessStatusCode)
            {
                var finishedProductList = await finishedProductsResponse.Content.ReadFromJsonAsync<List<ProductListDto>>();
                var finishedProductListVm = _mapper.Map<List<ProductListViewModel>>(finishedProductList);
                return View(finishedProductListVm);
            }
            return View();

        }



        public async Task<IActionResult> RoleAssignUser()
        {
            var userWithRoleResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + "/User/admin-get-users-with-roles/");
            if (userWithRoleResponse.IsSuccessStatusCode)
            {
                var userWithRoleDto = await userWithRoleResponse.Content.ReadFromJsonAsync<List<UserWithRoleDto>>();
                var userWithRoleVM = _mapper.Map<List<UserRoleViewModel>>(userWithRoleDto);
                return View(userWithRoleVM);
            }
            return View();

        }


    }
}
