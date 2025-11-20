using MediatR;
using MyProject.Bussines.CQRS.Orders.Commands.Request;
using MyProject.Bussines.CQRS.Orders.Commands.Response;
using MyProject.Bussines.Exceptions;
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
        private readonly IOrderRepository _orderRepository;

        public CancelOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(CancelOrderCommandRequest request, CancellationToken cancellationToken)
        {
            if (!await _orderRepository.DeleteAsync(request.OrderId))
            {
                throw new NotFoundException("Sipariş bulunamadı. İptal etme işlemi başarısız.");
            }
            return Unit.Value;
        }
    
    }
}
