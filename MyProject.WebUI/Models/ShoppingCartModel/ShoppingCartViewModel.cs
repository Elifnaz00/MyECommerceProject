using MyProject.Entity.Entities;
using MyProject.Entity.Enums;

namespace MyProject.WebUI.Models.ShoppingCartModel
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartGetItemsViewModel> BasketItems { get; set; } = new();

        public decimal TotalPrice { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public BasketStatus BasketStatus { get; set; }
    }
}
