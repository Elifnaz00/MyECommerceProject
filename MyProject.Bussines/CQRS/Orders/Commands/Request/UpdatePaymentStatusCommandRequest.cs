using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MyProject.Bussines.CQRS.Orders.Commands.Request
{
    public class UpdatePaymentStatusCommandRequest: IRequest<bool>
    {
        public Guid OrderId { get; set; }
        public Guid PaymentStatusId { get; set; }
    }
}
