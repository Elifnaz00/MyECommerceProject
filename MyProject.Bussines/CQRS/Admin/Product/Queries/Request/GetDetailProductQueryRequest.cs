using MediatR;
using MyProject.DTO.DTOs.AdminDTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Product.Queries.Request
{
    public class GetDetailProductQueryRequest : IRequest<ProductDetailDto>
    {
        public Guid Id { get; set; }
    }
}
