using MyProject.WebUI.Models.ProductModel;

namespace MyProject.WebUI.Models.ShoppingCartModel
{
    public class ShoppingCartGetItemsViewModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public ShoppingCartProductViewModel Product { get; set; }
    }
}
