using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using MediatR;
using MyProject.Bussines.CQRS.Orders.Commands.Request;
using MyProject.DataAccess.Abstract;

namespace MyProject.Bussines.CQRS.Orders.Handlers
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommandRequest, bool>
    {
        private readonly IOrderRepository _orderRepository;
       

        public UpdateOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
           
        }

        public async Task<bool> Handle(UpdateOrderStatusCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var orderId = await _orderRepository.GetByIdAsync(request.OrderId);
                if (orderId == null) return false;

                orderId.OrderStatusId = request.OrderStatusId;
                await _orderRepository.UpdateAsync(orderId);
                return true;
            }
            catch 
            {
               
                return false;
            }
        }
    }
}
