using MediatR;
using System;

namespace MyProject.Bussines.CQRS.Orders.Commands.Request
{
    public class CancelOrderCommandRequest : IRequest<Unit> 
    {
        public Guid OrderId { get; set; }
    }
}
