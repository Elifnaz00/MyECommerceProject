using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DTO.DTOs.BasketItemDTOs;

namespace MyProject.Bussines.CQRS.BasketItem.Commands.Response
{
    public class AddBasketItemCommandResponse
    {
        public BasketItemDto BasketItem { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
