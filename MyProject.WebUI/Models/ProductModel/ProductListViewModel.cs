using MyProject.Entity.Entities;

namespace MyProject.WebUI.Models.ProductModel
{
    public class ProductListViewModel
    {
        public Guid Id { get; set; }    
        public string? Title { get; set; }

        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public string? Size { get; set; }

        public string? Color { get; set; }


        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
