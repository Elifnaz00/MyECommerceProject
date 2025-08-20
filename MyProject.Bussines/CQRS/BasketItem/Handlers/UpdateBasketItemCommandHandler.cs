using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.Bussines.CQRS.BasketItem.Commands.Request;
using MyProject.Bussines.CQRS.BasketItem.Commands.Response;

namespace MyProject.Bussines.CQRS.BasketItem.Handlers
{
    public class UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemCommandRequest, UpdateBasketItemCommandResponse>
    {
        public Task<UpdateBasketItemCommandResponse> Handle(UpdateBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
