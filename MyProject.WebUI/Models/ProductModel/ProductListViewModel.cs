using MyProject.DTO.DTOs.CategoryDTOs;
using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.Entity.Entities;
using MyProject.Entity.Enums;
using MyProject.TokenDTOs.DTOs.CategoryDTOs;

namespace MyProject.WebUI.Models.ProductModel
{
    public class ProductListViewModel
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public List<CategoryTypesDto> Categories { get; set; } = new List<CategoryTypesDto>();
        



    }
}
