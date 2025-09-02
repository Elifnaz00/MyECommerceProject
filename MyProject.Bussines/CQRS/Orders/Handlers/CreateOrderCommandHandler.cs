using AutoMapper;
using MediatR;
using MyProject.DataAccess.Abstract;
using MyProject.Bussines.CQRS.Orders.Commands.Request;
using MyProject.Bussines.CQRS.Orders.Commands.Response;
using MyProject.DTO.DTOs.OrderDTOs;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MyProject.Bussines.CQRS.Orders.Handlers
{
    public class CreateOrderCommandRequestHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor; // Add this field

        public CreateOrderCommandRequestHandler(IOrderRepository orderRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) // Update constructor
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor; // Assign the injected dependency
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.CreateOrderDto == null)
            {
                return new() { IsSuccess = false, Message = "Sipariş bilgileri eksik." };
            }

            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return new()
                {
                    IsSuccess = false,
                    Message = "Kullanıcı kimliği bulunamadı."
                };
            }

            var mappingValue = _mapper.Map<Order>(request.CreateOrderDto);

            if (mappingValue.PaymentStatusId == Guid.Empty)
                mappingValue.PaymentStatusId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            if (mappingValue.OrderStatusId == Guid.Empty)
                mappingValue.OrderStatusId = Guid.Parse("22222222-2222-2222-2222-222222222222");

            await _orderRepository.AddAsync(mappingValue);

            return new CreateOrderCommandResponse
            {
                IsSuccess = true,
                OrderDto = _mapper.Map<OrderDto>(mappingValue),
                Message = "Siparişiniz başarıyla oluşturuldu."
            };
        }
    }
}
