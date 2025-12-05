using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyProject.Bussines.CQRS.Admin.Order.Queries.Request;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Order.Handlers
{
    public class GetActiveOrderQueryHandler : IRequestHandler<GetActiveOrderQueryRequest, List<OrderListDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetActiveOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async  Task<List<OrderListDto>> Handle(GetActiveOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var value= await _orderRepository.GetActiveOrderListAsync();
            return value;
        }
    }
}
