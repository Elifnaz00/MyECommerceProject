using MyProject.DTO.DTOs.CategoryDTOs;
using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.Entity.Entities;
using MyProject.TokenDTOs.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Products.Queries.Response
{
    public class GetAllProductQueryResponse
    {
        public List<ProductDto> Products { get; set; }
        public List<CategoryTypesDto> Categories { get; set; }

       
    }
}
