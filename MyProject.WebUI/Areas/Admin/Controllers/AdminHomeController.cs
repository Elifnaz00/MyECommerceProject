using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    [Authorize(Roles = "Admin")]
    public class AdminHomeController : BaseAdminController
    {

        private readonly IMapper _mapper;
        public AdminHomeController(
             IHttpClientFactory httpClientFactory,
             IHttpContextAccessor contextAccessor,
             IMapper mapper)
             : base(httpClientFactory, contextAccessor)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var client = CreateClient();
            var dashBoardResponse = await client.GetAsync("Dashboard/get-dashboard-data");

            if (dashBoardResponse.IsSuccessStatusCode)
            {
                var EmpResponse = await dashBoardResponse.Content.ReadFromJsonAsync<DashboardViewModel>();
                return View(EmpResponse);
            }

            return View();
        }


        public async Task<IActionResult> Customers()
        {
            var client = CreateClient();
            var dashBoardResponse = await client.GetAsync("User/admin-get-userlist");
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
            var client = CreateClient();
            var activeOrderResponse = await client.GetAsync("Order/admin-get-active-orderlist");
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
            var client = CreateClient();
            var cancelledOrderResponse = await client.GetAsync("Order/admin-get-cancelled-orderlist");
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
            var client = CreateClient();
            var availableProductsResponse = await client.GetAsync("Product/get-avaiable-product-list");
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
            var client = CreateClient();
            var finishedProductsResponse = await client.GetAsync("Product/get-finished-product-list");
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
            var client = CreateClient();
            var userWithRoleResponse = await client.GetAsync("User/admin-get-users-with-roles/");
            if (userWithRoleResponse.IsSuccessStatusCode)
            {
                var userWithRoleDto = await userWithRoleResponse.Content.ReadFromJsonAsync<List<UserWithRoleDto>>();
                var userWithRoleVM = _mapper.Map<List<UserRoleViewModel>>(userWithRoleDto);
                return View(userWithRoleVM);
            }
            return View();

        }


        public async Task<IActionResult> Logout()
        {
            var client = CreateClient();
            var logoutResponse = await client.PostAsync("User/admin-logout", null);
            if (logoutResponse.IsSuccessStatusCode)
            {
                await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
                Response.Cookies.Delete("ApiAccessToken");
                HttpContext.Session.Clear();

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return RedirectToAction("Index", "AdminHome", new { area = "Admin" });


        }
    }
}
