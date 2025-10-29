using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.Bussines.CQRS.Admin.Dashboard.Queries.Request;
using MyProject.Bussines.CQRS.Admin.Dashboard.Queries.Response;
using MyProject.DataAccess.Abstract;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.CQRS.Admin.Dashboard.Handlers
{
    public class GetDashboardDataQueryHandler : IRequestHandler<GetDashboardDataQueryRequest, GetDashboardDataQueryResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<AppUser> _userManager;

        public GetDashboardDataQueryHandler(IOrderRepository orderRepository, IProductRepository productRepository, UserManager<AppUser> userManager)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userManager = userManager;
        }

        public async Task<GetDashboardDataQueryResponse> Handle(GetDashboardDataQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var allOrders = _orderRepository.GetOrderCount();

                var allProduct = _productRepository.GetProductCount();

                var totalAmountOrder = _orderRepository.GetOrderTotalAmount();

                return new()
                {
                    TotalOrder = allOrders,
                    TotalProduct = allProduct,
                    TotalAmountOrder = totalAmountOrder,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    IsSuccess = false,
                    Message =  "Veriler listelenemedi."
                };

            }

        }
    }
}
