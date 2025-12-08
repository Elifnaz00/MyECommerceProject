using MediatR;
using MyProject.DTO.DTOs.AdminDTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Product.Command.Request
{
    public class UpdateProductCommandRequest : IRequest<Unit>   
    {
        public Guid Id { get; set; }

        public UpdateProductDto UpdateProductDto { get; set; }
    }
}
