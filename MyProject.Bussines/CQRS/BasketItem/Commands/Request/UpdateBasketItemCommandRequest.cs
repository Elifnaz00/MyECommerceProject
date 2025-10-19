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
    public class UpdateBasketItemCommandRequest: IRequest<UpdateBasketItemCommandResponse>
    {
        public Guid Id { get; set; }    
        public int Quantity { get; set; }
    }
}
