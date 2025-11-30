using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MyProject.Bussines.CQRS.Orders.Queries.Request;
using MyProject.Bussines.CQRS.Orders.Queries.Response;
using MyProject.Bussines.Exceptions;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.DTOs.BasketItemDTOs;
using MyProject.DTO.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UnauthorizedAccessException = MyProject.Bussines.Exceptions.UnauthorizedAccessException;

namespace MyProject.Bussines.CQRS.Orders.Handlers
{
    public class GetUserOrderQueryHandler : IRequestHandler<GetUserOrderQueryRequest, GetUserOrderQueryResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetUserOrderQueryResponse> Handle(GetUserOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("Lütfen giriş yapınız.");
            }

            var orders = await _orderRepository.GetOrdersByUserId(userId);
            if (orders == null || !orders.Any()) {
                throw new NotFoundException("Order not found");
            }
            
            return new GetUserOrderQueryResponse
            {
                IsSuccess = true,
                OrdersDto = _mapper.Map<List<UserOrderDto>>(orders),
                Message = "Kullanıcının siparişleri başarıyla getirildi."
               
            };



        }
    }
}
