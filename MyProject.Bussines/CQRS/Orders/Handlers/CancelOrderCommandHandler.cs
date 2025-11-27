using MediatR;
using MyProject.Bussines.CQRS.Orders.Commands.Request;
using MyProject.Bussines.CQRS.Orders.Commands.Response;
using MyProject.Bussines.Exceptions;
using MyProject.Bussines.Services;
using MyProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Orders.Handlers
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommandRequest, Unit>
    {
      
        private readonly IOrderService _orderService;

        public CancelOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<Unit> Handle(CancelOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _orderService.CancelOrderServiceAsync(request.OrderId);
            return Unit.Value;
        }
    
    }
}
