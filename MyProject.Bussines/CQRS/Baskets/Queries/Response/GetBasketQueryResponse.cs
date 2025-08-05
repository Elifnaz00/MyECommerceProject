using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DTO.DTOs.BasketItemDTOs;
using MyProject.Entity.Enums;

namespace MyProject.Bussines.CQRS.Baskets.Queries.Response
{
    public class GetBasketQueryResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public IEnumerable<BasketItemDto> BasketItems { get; set; }
        public BasketStatus BasketStatus { get; set; } //Enum ekledim

    }
}
