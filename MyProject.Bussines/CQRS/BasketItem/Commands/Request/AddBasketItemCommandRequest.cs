using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.Bussines.CQRS.BasketItem.Commands.Response;
using MyProject.DTO.DTOs.BasketItemDTOs;

namespace MyProject.Bussines.CQRS.BasketItem.Commands.Request
{
    public class AddBasketItemCommandRequest : IRequest<AddBasketItemCommandResponse>
    {
        public Guid ProductId { get; set; }
    }

   
}
