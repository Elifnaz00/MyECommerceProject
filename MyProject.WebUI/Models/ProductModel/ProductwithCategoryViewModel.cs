using MyProject.WebUI.Models.CategoryModel;

namespace MyProject.WebUI.Models.ProductModel
{
    public class ProductwithCategoryViewModel
    {
        public List<ProductListViewModel> Products { get; set; } = new List<ProductListViewModel>();
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
