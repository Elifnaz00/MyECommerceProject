using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MyProject.Bussines.CQRS.Orders.Queries.Request;
using MyProject.Bussines.Exceptions;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Orders.Handlers.QueryHandlers
{
    public class UserOrderDetailQueryHandler : IRequestHandler<UserOrderDetailQueryRequest, OrderDetailDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserOrderDetailQueryHandler(IOrderRepository orderRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<OrderDetailDto> Handle(UserOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
               throw new UnauthorizedException("Lütfen giriş yapınız.");
            }
            var userOrderDetail= await _orderRepository.GetUserOrderDetailAsync(request.OrderId, userId);
            if (userOrderDetail is null)
                throw new NotFoundException("Sipariş bulunamadı.");

            return _mapper.Map<OrderDetailDto>(userOrderDetail); 
        }
    }
}
