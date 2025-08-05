using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.Bussines.CQRS.BasketItem.Commands.Response;

namespace MyProject.Bussines.CQRS.BasketItem.Commands.Request
{
    
    public class DeleteBasketItemCommandRequest : IRequest<DeleteBasketItemCommandResponse>
    {
        public Guid Id { get; set; }
    }

   
}
