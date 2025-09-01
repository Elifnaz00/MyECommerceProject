﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.Bussines.CQRS.Orders.Commands.Request;
using MyProject.DataAccess.Abstract;

namespace MyProject.Bussines.CQRS.Orders.Handlers
{
    public class UpdatePaymentStatusCommandHandler : IRequestHandler<UpdatePaymentStatusCommandRequest, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdatePaymentStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(UpdatePaymentStatusCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            if (order == null) return false;

            order.PaymentStatusId = request.PaymentStatusId;
           
            if (request.PaymentStatusId == Guid.Parse("33333333-3333-3333-3333-333333333333")) // Paid
                order.OrderStatusId = Guid.Parse("55555555-5555-5555-5555-555555555555"); // Processing

            _orderRepository.Update(order);

            return true;
        }
    }
}
