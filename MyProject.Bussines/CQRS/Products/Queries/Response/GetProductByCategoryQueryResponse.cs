using MyProject.DTO.DTOs.CategoryDTOs;
using MyProject.DTO.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Products.Queries.Response
{
    public class GetProductByCategoryQueryResponse
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public List<CategoryTypesDto> Categories { get; set; } = new List<CategoryTypesDto>();


    }
}
