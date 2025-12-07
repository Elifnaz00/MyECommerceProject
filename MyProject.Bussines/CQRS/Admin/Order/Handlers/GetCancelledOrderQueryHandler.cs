using AutoMapper;
using MediatR;
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
    public class GetCancelledOrderQueryHandler : IRequestHandler<GetCancelledOrderQueryRequest, List<OrderListDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetCancelledOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderListDto>> Handle(GetCancelledOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var activeOrderListExec = await _orderRepository.GetCanceledOrderListAsync();
            return _mapper.Map<List<OrderListDto>>(activeOrderListExec);
        }
    }
}
