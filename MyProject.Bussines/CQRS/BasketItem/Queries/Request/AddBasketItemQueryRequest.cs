using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.DTO.DTOs.BasketItemDTOs;
using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.CQRS.BasketItem.Queries.Request
{
    public class AddBasketItemQueryRequest : IRequest<AddBasketItemQueryResponse>
    {

        public Guid ProductId { get; set; }

    }

    public class AddBasketItemQueryResponse
    {
        public BasketItemDto BasketItem { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

    }
}
