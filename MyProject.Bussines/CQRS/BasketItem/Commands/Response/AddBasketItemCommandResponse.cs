using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DTO.DTOs.BaseDTO;
using MyProject.DTO.DTOs.BasketItemDTOs;

namespace MyProject.Bussines.CQRS.BasketItem.Commands.Response
{
    public class AddBasketItemCommandResponse: BaseResponse
    {
        public BasketItemDto BasketItem { get; set; }
      
    }
}
