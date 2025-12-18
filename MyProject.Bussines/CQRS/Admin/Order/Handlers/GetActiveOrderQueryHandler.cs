using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyProject.Bussines.CQRS.Admin.Order.Queries.Request;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.DTOs.OrderDTOs;
using MyProject.DTO.DTOs.OrderStatusDTOs;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Order.Handlers
{
    public class GetActiveOrderQueryHandler : IRequestHandler<GetActiveOrderQueryRequest, GetActiveOrderListDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IMapper _mapper;

        public GetActiveOrderQueryHandler(IOrderRepository orderRepository, IOrderStatusRepository orderStatusRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderStatusRepository = orderStatusRepository;
            _mapper = mapper;
        }

        public async Task<GetActiveOrderListDto> Handle(GetActiveOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var activeOrderListExec = await _orderRepository.GetActiveOrderListAsync();
            var orderStatusLists= await _orderStatusRepository.GetAll().ToListAsync();
            return new GetActiveOrderListDto
            {
                Orders = _mapper.Map<List<OrderListDto>>(activeOrderListExec),
                OrderStatuses = _mapper.Map<List<OrderStatusDto>>(orderStatusLists)
            };

        }
    }
}
