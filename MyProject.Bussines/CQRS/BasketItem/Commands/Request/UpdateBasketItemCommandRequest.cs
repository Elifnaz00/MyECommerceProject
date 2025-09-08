using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.DTO.DTOs.BasketItemDTOs;

namespace MyProject.Bussines.CQRS.BasketItem.Commands.Request
{
    public class UpdateBasketItemCommandRequest: IRequest<bool>
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
