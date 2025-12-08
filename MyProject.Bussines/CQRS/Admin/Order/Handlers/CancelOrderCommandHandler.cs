using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Order.Commands.Request;
using MyProject.Bussines.Exceptions;
using MyProject.DataAccess.Abstract;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Order.Handlers
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommandRequest, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CancelOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CancelOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var hasOrder= await _orderRepository.FindByIdAsync(request.OrderId);
            if(hasOrder == null)
            {
                throw new NotFoundException("İptal etmek istenen sipariş bulunamadı.");
            }
            hasOrder.IsDeleted = true;
            hasOrder.OrderStatusId = Guid.Parse("88888888-8888-8888-8888-888888888888");
            await _orderRepository.UpdateAsync(hasOrder);
            return Unit.Value;
        }
    }
}
