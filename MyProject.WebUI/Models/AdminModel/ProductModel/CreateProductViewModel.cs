using MyProject.DTO.DTOs.AdminDTOs.CategoryDto;
using MyProject.Entity.Enums;

namespace MyProject.WebUI.Models.AdminModel.ProductModel
{
    public class CreateProductViewModel
    {
        public Renkler Renkler { get; set; }
        public Bedenler Bedenler { get; set; }
        public string? Title { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public string? ImageUrl { get; set; }
        public List<CategoryDto> CategoryDtos { get; set; }
        public Guid CategoryId { get; set; }
    }
}
