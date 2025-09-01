using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MyProject.Bussines.CQRS.Orders.Commands.Request
{
    public class UpdateOrderStatusCommandRequest: IRequest<bool>
    {
        public Guid OrderId { get; set; }
        public Guid OrderStatusId { get; set; }
    }
}
