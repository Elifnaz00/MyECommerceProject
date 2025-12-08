using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Order.Queries.Request;
using MyProject.Bussines.Exceptions;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Order.Handlers
{
    public class DetailOrderQueryHandler : IRequestHandler<DetailOrderQueryRequest, OrderDetailDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public DetailOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDetailDto> Handle(DetailOrderQueryRequest request, CancellationToken cancellationToken)
        {

            var orderDetailobj = await _orderRepository.GetOrderDetailAsync(request.Id);
            if(orderDetailobj is null)
            {
                throw new NotFoundException("Sipariş detayı bulunamadı.");
            }
            return _mapper.Map<OrderDetailDto>(orderDetailobj);
        }
    }
}
