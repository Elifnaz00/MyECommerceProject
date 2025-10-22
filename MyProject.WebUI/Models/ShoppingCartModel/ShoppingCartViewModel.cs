using MyProject.Entity.Entities;
using MyProject.Entity.Enums;

namespace MyProject.WebUI.Models.ShoppingCartModel
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCartGetItemsViewModel> BasketItems { get; set; }

        public decimal TotalPrice { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public BasketStatus BasketStatus { get; set; }
    }
}
