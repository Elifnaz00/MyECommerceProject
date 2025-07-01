using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.DTO.DTOs.BasketDTOs;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.CQRS.Baskets.Queries.Request
{
    public class AddBasketQueryRequest: IRequest<AddBasketQueryResponse>
    {

        public string AppUserId { get; set; }
        public bool Active { get; set; }


    }

    public class AddBasketQueryResponse
    {
        public AddBasketDto AddBasketDto { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
