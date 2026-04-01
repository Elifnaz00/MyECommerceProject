using MyProject.WebUI.Models.CategoryModel;

namespace MyProject.WebUI.Models.ProductModel
{
    public class ProductwithCategoryViewModel
    {
        public IEnumerable<ProductListViewModel> Products { get; set; } = new List<ProductListViewModel>();
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
