using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Order.Commands.Request;
using MyProject.Bussines.Exceptions;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.Models.OrderStatusViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Order.Handlers
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommandRequest, Unit>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
           
        }

        public async Task<Unit> Handle(UpdateOrderStatusCommandRequest request, CancellationToken cancellationToken)
        {
            var hasOrder = await _orderRepository.GetByIdAsync(request.OrderId);
            if (hasOrder is null)
            {
                throw new NotFoundException("Order not found");
            }
            hasOrder.OrderStatusId = request.StatusId;
            await _orderRepository.UpdateAsync(hasOrder);
                
            return Unit.Value;
        }
    }
}
