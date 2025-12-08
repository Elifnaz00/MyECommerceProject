using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Order.Commands.Request
{
    public class CancelOrderCommandRequest : IRequest<Unit> 
    {
        public Guid OrderId { get; set; }
    }
}
