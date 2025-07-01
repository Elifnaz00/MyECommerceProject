using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.CQRS.Products.Commands
{
    public class AddProductCommandRequest: IRequest<AddProductCommandResponse>
    {
        
        public AddProductDto ProductValues { get; set; }
        

    }


    public class AddProductCommandResponse
    {
        public ProductDto ProductDto { get; set; }
    }
}
