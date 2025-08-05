using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DTO.DTOs.BasketDTOs;

namespace MyProject.Bussines.CQRS.Baskets.Queries.Response
{
    public class AddBasketQueryResponse
    {
        public AddBasketDto AddBasketDto { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
