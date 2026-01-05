using MyProject.Entity.Entities;

namespace MyProject.WebUI.Models.AdminModel.ProductModel
{
    public class DetailProductViewModel
    {
        public string? Title { get; set; }

        public int Stock { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public string? ImageUrl { get; set; }

        public string? Size { get; set; }

        public string? Color { get; set; }

        public string CategoryCategoryName { get; set; }
        public DateTime CreateDate { get; set; }



    }
}
